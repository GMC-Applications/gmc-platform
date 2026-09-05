-- GMC Church Platform - PostgreSQL local database schema
-- Run after creating the database: psql -U postgres -d gmc_platform -f schema.sql
-- This schema is intentionally provider-neutral and can also be used with Supabase PostgreSQL.

CREATE EXTENSION IF NOT EXISTS pgcrypto;

CREATE TYPE user_status AS ENUM ('active','inactive','pending','suspended');
CREATE TYPE prayer_status AS ENUM ('pending','approved','rejected','prayed');
CREATE TYPE content_status AS ENUM ('draft','pending_review','published','archived');
CREATE TYPE serving_status AS ENUM ('pending','accepted','declined','substitute_requested','replaced');
CREATE TYPE payment_status AS ENUM ('pending','completed','failed','cancelled','refunded');
CREATE TYPE visitor_status AS ENUM ('new','contacted','connected','converted','closed');

CREATE TABLE roles (
    id BIGSERIAL PRIMARY KEY,
    name VARCHAR(80) NOT NULL UNIQUE,
    description VARCHAR(255),
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW()
);

CREATE TABLE permissions (
    id BIGSERIAL PRIMARY KEY,
    code VARCHAR(120) NOT NULL UNIQUE,
    description VARCHAR(255)
);

CREATE TABLE role_permissions (
    role_id BIGINT NOT NULL REFERENCES roles(id) ON DELETE CASCADE,
    permission_id BIGINT NOT NULL REFERENCES permissions(id) ON DELETE CASCADE,
    PRIMARY KEY (role_id, permission_id)
);

CREATE TABLE users (
    id BIGSERIAL PRIMARY KEY,
    email VARCHAR(255) NOT NULL UNIQUE,
    password_hash TEXT NOT NULL,
    full_name VARCHAR(160) NOT NULL,
    phone VARCHAR(40),
    status user_status NOT NULL DEFAULT 'active',
    email_verified_at TIMESTAMPTZ,
    last_login_at TIMESTAMPTZ,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    updated_at TIMESTAMPTZ
);

CREATE TABLE user_roles (
    user_id BIGINT NOT NULL REFERENCES users(id) ON DELETE CASCADE,
    role_id BIGINT NOT NULL REFERENCES roles(id) ON DELETE CASCADE,
    PRIMARY KEY (user_id, role_id)
);

CREATE TABLE refresh_tokens (
    id BIGSERIAL PRIMARY KEY,
    user_id BIGINT NOT NULL REFERENCES users(id) ON DELETE CASCADE,
    token_hash TEXT NOT NULL UNIQUE,
    expires_at TIMESTAMPTZ NOT NULL,
    revoked_at TIMESTAMPTZ,
    device_name VARCHAR(120),
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW()
);

CREATE TABLE members (
    id BIGSERIAL PRIMARY KEY,
    user_id BIGINT UNIQUE REFERENCES users(id) ON DELETE SET NULL,
    first_name VARCHAR(80) NOT NULL,
    last_name VARCHAR(80) NOT NULL,
    email VARCHAR(255),
    phone VARCHAR(40),
    date_of_birth DATE,
    address TEXT,
    member_since DATE,
    membership_status VARCHAR(50) NOT NULL DEFAULT 'active',
    profile_visibility VARCHAR(30) NOT NULL DEFAULT 'church',
    communication_consent BOOLEAN NOT NULL DEFAULT TRUE,
    emergency_contact_name VARCHAR(160),
    emergency_contact_phone VARCHAR(40),
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    updated_at TIMESTAMPTZ
);

CREATE TABLE visitors (
    id BIGSERIAL PRIMARY KEY,
    first_name VARCHAR(80) NOT NULL,
    last_name VARCHAR(80) NOT NULL,
    email VARCHAR(255),
    phone VARCHAR(40),
    visit_date DATE NOT NULL DEFAULT CURRENT_DATE,
    notes TEXT,
    status visitor_status NOT NULL DEFAULT 'new',
    converted_member_id BIGINT REFERENCES members(id) ON DELETE SET NULL,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    updated_at TIMESTAMPTZ
);

CREATE TABLE ministries (
    id BIGSERIAL PRIMARY KEY,
    name VARCHAR(160) NOT NULL,
    description TEXT,
    image_url TEXT,
    active BOOLEAN NOT NULL DEFAULT TRUE,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    updated_at TIMESTAMPTZ
);

CREATE TABLE ministry_members (
    ministry_id BIGINT NOT NULL REFERENCES ministries(id) ON DELETE CASCADE,
    member_id BIGINT NOT NULL REFERENCES members(id) ON DELETE CASCADE,
    is_leader BOOLEAN NOT NULL DEFAULT FALSE,
    joined_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    PRIMARY KEY (ministry_id, member_id)
);

CREATE TABLE small_groups (
    id BIGSERIAL PRIMARY KEY,
    ministry_id BIGINT REFERENCES ministries(id) ON DELETE SET NULL,
    name VARCHAR(160) NOT NULL,
    description TEXT,
    meeting_day VARCHAR(30),
    meeting_time TIME,
    location VARCHAR(255),
    leader_member_id BIGINT REFERENCES members(id) ON DELETE SET NULL,
    active BOOLEAN NOT NULL DEFAULT TRUE,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    updated_at TIMESTAMPTZ
);

CREATE TABLE small_group_members (
    small_group_id BIGINT NOT NULL REFERENCES small_groups(id) ON DELETE CASCADE,
    member_id BIGINT NOT NULL REFERENCES members(id) ON DELETE CASCADE,
    joined_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    PRIMARY KEY (small_group_id, member_id)
);

CREATE TABLE announcements (
    id BIGSERIAL PRIMARY KEY,
    title VARCHAR(180) NOT NULL,
    body TEXT NOT NULL,
    image_url TEXT,
    status content_status NOT NULL DEFAULT 'draft',
    target_role VARCHAR(80),
    ministry_id BIGINT REFERENCES ministries(id) ON DELETE SET NULL,
    scheduled_at TIMESTAMPTZ,
    published_at TIMESTAMPTZ,
    created_by BIGINT REFERENCES users(id) ON DELETE SET NULL,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    updated_at TIMESTAMPTZ
);

CREATE TABLE sermons (
    id BIGSERIAL PRIMARY KEY,
    title VARCHAR(180) NOT NULL,
    description TEXT,
    speaker VARCHAR(160),
    sermon_date DATE NOT NULL,
    video_url TEXT,
    audio_url TEXT,
    thumbnail_url TEXT,
    status content_status NOT NULL DEFAULT 'draft',
    created_by BIGINT REFERENCES users(id) ON DELETE SET NULL,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    updated_at TIMESTAMPTZ
);

CREATE TABLE podcasts (
    id BIGSERIAL PRIMARY KEY,
    title VARCHAR(180) NOT NULL,
    description TEXT,
    audio_url TEXT NOT NULL,
    cover_image_url TEXT,
    published_at TIMESTAMPTZ,
    status content_status NOT NULL DEFAULT 'draft',
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW()
);

CREATE TABLE church_events (
    id BIGSERIAL PRIMARY KEY,
    title VARCHAR(180) NOT NULL,
    description TEXT,
    location VARCHAR(255),
    starts_at TIMESTAMPTZ NOT NULL,
    ends_at TIMESTAMPTZ,
    capacity INTEGER,
    registration_required BOOLEAN NOT NULL DEFAULT FALSE,
    status content_status NOT NULL DEFAULT 'draft',
    created_by BIGINT REFERENCES users(id) ON DELETE SET NULL,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    updated_at TIMESTAMPTZ
);

CREATE TABLE event_registrations (
    id BIGSERIAL PRIMARY KEY,
    event_id BIGINT NOT NULL REFERENCES church_events(id) ON DELETE CASCADE,
    member_id BIGINT REFERENCES members(id) ON DELETE SET NULL,
    visitor_id BIGINT REFERENCES visitors(id) ON DELETE SET NULL,
    registered_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    UNIQUE (event_id, member_id),
    UNIQUE (event_id, visitor_id),
    CHECK (member_id IS NOT NULL OR visitor_id IS NOT NULL)
);

CREATE TABLE sermon_notes (
    id BIGSERIAL PRIMARY KEY,
    sermon_id BIGINT NOT NULL REFERENCES sermons(id) ON DELETE CASCADE,
    member_id BIGINT NOT NULL REFERENCES members(id) ON DELETE CASCADE,
    notes TEXT NOT NULL DEFAULT '',
    updated_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    UNIQUE (sermon_id, member_id)
);

CREATE TABLE prayer_requests (
    id BIGSERIAL PRIMARY KEY,
    member_id BIGINT REFERENCES members(id) ON DELETE SET NULL,
    name VARCHAR(160),
    request TEXT NOT NULL,
    anonymous BOOLEAN NOT NULL DEFAULT FALSE,
    status prayer_status NOT NULL DEFAULT 'pending',
    moderated_by BIGINT REFERENCES users(id) ON DELETE SET NULL,
    moderated_at TIMESTAMPTZ,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW()
);

CREATE TABLE children (
    id BIGSERIAL PRIMARY KEY,
    first_name VARCHAR(80) NOT NULL,
    last_name VARCHAR(80) NOT NULL,
    date_of_birth DATE,
    allergies TEXT,
    medical_notes TEXT,
    active BOOLEAN NOT NULL DEFAULT TRUE,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW()
);

CREATE TABLE child_guardians (
    child_id BIGINT NOT NULL REFERENCES children(id) ON DELETE CASCADE,
    member_id BIGINT NOT NULL REFERENCES members(id) ON DELETE CASCADE,
    relationship VARCHAR(50),
    authorized_pickup BOOLEAN NOT NULL DEFAULT TRUE,
    PRIMARY KEY (child_id, member_id)
);

CREATE TABLE child_checkins (
    id BIGSERIAL PRIMARY KEY,
    child_id BIGINT NOT NULL REFERENCES children(id) ON DELETE RESTRICT,
    checked_in_by BIGINT NOT NULL REFERENCES members(id) ON DELETE RESTRICT,
    checked_in_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    checked_out_by BIGINT REFERENCES members(id) ON DELETE SET NULL,
    checked_out_at TIMESTAMPTZ,
    security_code VARCHAR(30) NOT NULL,
    notes TEXT
);

CREATE TABLE serving_roles (
    id BIGSERIAL PRIMARY KEY,
    ministry_id BIGINT REFERENCES ministries(id) ON DELETE SET NULL,
    name VARCHAR(120) NOT NULL,
    description TEXT,
    active BOOLEAN NOT NULL DEFAULT TRUE
);

CREATE TABLE serving_schedules (
    id BIGSERIAL PRIMARY KEY,
    serving_role_id BIGINT NOT NULL REFERENCES serving_roles(id) ON DELETE CASCADE,
    scheduled_for TIMESTAMPTZ NOT NULL,
    location VARCHAR(255),
    notes TEXT,
    created_by BIGINT REFERENCES users(id) ON DELETE SET NULL,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW()
);

CREATE TABLE serving_requests (
    id BIGSERIAL PRIMARY KEY,
    schedule_id BIGINT NOT NULL REFERENCES serving_schedules(id) ON DELETE CASCADE,
    member_id BIGINT NOT NULL REFERENCES members(id) ON DELETE CASCADE,
    status serving_status NOT NULL DEFAULT 'pending',
    responded_at TIMESTAMPTZ,
    substitute_member_id BIGINT REFERENCES members(id) ON DELETE SET NULL,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    UNIQUE (schedule_id, member_id)
);

CREATE TABLE notification_devices (
    id BIGSERIAL PRIMARY KEY,
    user_id BIGINT NOT NULL REFERENCES users(id) ON DELETE CASCADE,
    fcm_token TEXT NOT NULL UNIQUE,
    platform VARCHAR(20) NOT NULL,
    active BOOLEAN NOT NULL DEFAULT TRUE,
    last_seen_at TIMESTAMPTZ
);

CREATE TABLE notifications (
    id BIGSERIAL PRIMARY KEY,
    title VARCHAR(180) NOT NULL,
    body TEXT NOT NULL,
    target_type VARCHAR(40) NOT NULL,
    target_id BIGINT,
    scheduled_at TIMESTAMPTZ,
    sent_at TIMESTAMPTZ,
    created_by BIGINT REFERENCES users(id) ON DELETE SET NULL,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW()
);

CREATE TABLE notification_deliveries (
    id BIGSERIAL PRIMARY KEY,
    notification_id BIGINT NOT NULL REFERENCES notifications(id) ON DELETE CASCADE,
    user_id BIGINT NOT NULL REFERENCES users(id) ON DELETE CASCADE,
    status VARCHAR(30) NOT NULL DEFAULT 'queued',
    delivered_at TIMESTAMPTZ,
    failure_reason TEXT
);

CREATE TABLE connection_submissions (
    id BIGSERIAL PRIMARY KEY,
    member_id BIGINT REFERENCES members(id) ON DELETE SET NULL,
    name VARCHAR(160) NOT NULL,
    email VARCHAR(255),
    interest VARCHAR(100),
    message TEXT,
    status VARCHAR(30) NOT NULL DEFAULT 'new',
    assigned_to BIGINT REFERENCES users(id) ON DELETE SET NULL,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    updated_at TIMESTAMPTZ
);

CREATE TABLE donations (
    id BIGSERIAL PRIMARY KEY,
    member_id BIGINT REFERENCES members(id) ON DELETE SET NULL,
    donor_name VARCHAR(160),
    donor_email VARCHAR(255),
    amount NUMERIC(12,2) NOT NULL CHECK (amount > 0),
    currency CHAR(3) NOT NULL DEFAULT 'ZAR',
    category VARCHAR(80) NOT NULL DEFAULT 'General',
    provider VARCHAR(40) NOT NULL DEFAULT 'PayFast',
    provider_reference VARCHAR(180) UNIQUE,
    status payment_status NOT NULL DEFAULT 'pending',
    paid_at TIMESTAMPTZ,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW()
);

CREATE TABLE recurring_giving (
    id BIGSERIAL PRIMARY KEY,
    member_id BIGINT REFERENCES members(id) ON DELETE SET NULL,
    amount NUMERIC(12,2) NOT NULL CHECK (amount > 0),
    currency CHAR(3) NOT NULL DEFAULT 'ZAR',
    frequency VARCHAR(30) NOT NULL,
    provider_reference VARCHAR(180) UNIQUE,
    status VARCHAR(30) NOT NULL DEFAULT 'active',
    next_payment_at TIMESTAMPTZ,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW()
);

CREATE TABLE event_payments (
    id BIGSERIAL PRIMARY KEY,
    event_id BIGINT NOT NULL REFERENCES church_events(id) ON DELETE RESTRICT,
    member_id BIGINT REFERENCES members(id) ON DELETE SET NULL,
    amount NUMERIC(12,2) NOT NULL CHECK (amount > 0),
    provider_reference VARCHAR(180) UNIQUE,
    status payment_status NOT NULL DEFAULT 'pending',
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW()
);

CREATE TABLE audit_logs (
    id BIGSERIAL PRIMARY KEY,
    user_id BIGINT REFERENCES users(id) ON DELETE SET NULL,
    action VARCHAR(120) NOT NULL,
    entity_type VARCHAR(80),
    entity_id BIGINT,
    ip_address INET,
    metadata JSONB,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW()
);

CREATE INDEX idx_users_status ON users(status);
CREATE INDEX idx_members_name ON members(last_name, first_name);
CREATE INDEX idx_visitors_status ON visitors(status);
CREATE INDEX idx_announcements_status ON announcements(status, published_at);
CREATE INDEX idx_sermons_date ON sermons(sermon_date DESC);
CREATE INDEX idx_events_date ON church_events(starts_at);
CREATE INDEX idx_prayers_status ON prayer_requests(status, created_at DESC);
CREATE INDEX idx_checkins_active ON child_checkins(child_id) WHERE checked_out_at IS NULL;
CREATE INDEX idx_donations_status_date ON donations(status, created_at DESC);
CREATE INDEX idx_audit_logs_user_date ON audit_logs(user_id, created_at DESC);

-- Seed roles
INSERT INTO roles (name, description) VALUES
 ('SuperAdministrator','Full platform access'),
 ('ChurchAdministrator','Church administration access'),
 ('Pastor','Leadership and pastoral access'),
 ('Staff','Assigned staff access'),
 ('MinistryDirector','Manage assigned ministries'),
 ('SmallGroupLeader','Manage assigned small group'),
 ('FinanceAdministrator','Manage donations and payments'),
 ('ContentManager','Manage sermons and announcements'),
 ('VolunteerCoordinator','Manage serving schedules'),
 ('CheckInAdministrator','Manage child check-in'),
 ('Member','Standard member access')
ON CONFLICT (name) DO NOTHING;

-- Seed core permissions
INSERT INTO permissions (code, description) VALUES
 ('users.view','View users'),('users.manage','Manage users'),
 ('members.view','View members'),('members.manage','Manage members'),
 ('ministries.view','View ministries'),('ministries.manage','Manage ministries'),
 ('groups.view','View groups'),('groups.manage','Manage groups'),
 ('content.view','View content'),('content.manage','Manage content'),('content.publish','Publish content'),
 ('events.view','View events'),('events.manage','Manage events'),
 ('prayers.view','View prayer requests'),('prayers.moderate','Moderate prayer requests'),
 ('volunteers.view','View serving'),('volunteers.manage','Manage serving'),
 ('checkin.view','View check-in'),('checkin.manage','Manage child check-in'),
 ('notifications.manage','Manage notifications'),('reports.view','View reports'),
 ('finance.view','View finances'),('finance.manage','Manage finances')
ON CONFLICT (code) DO NOTHING;

-- Give SuperAdministrator every permission
INSERT INTO role_permissions (role_id, permission_id)
SELECT r.id, p.id FROM roles r CROSS JOIN permissions p
WHERE r.name='SuperAdministrator'
ON CONFLICT DO NOTHING;
