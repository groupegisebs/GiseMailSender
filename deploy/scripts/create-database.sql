-- Exécuter UNE FOIS en tant que superuser postgres (si le déploiement auto échoue)
-- sudo -u postgres psql -f create-database.sql

SELECT 'CREATE DATABASE "GiseMailSenderService" OWNER gisedocuser'
WHERE NOT EXISTS (SELECT 1 FROM pg_database WHERE datname = 'GiseMailSenderService')\gexec

GRANT ALL PRIVILEGES ON DATABASE "GiseMailSenderService" TO gisedocuser;

\c "GiseMailSenderService"

GRANT ALL ON SCHEMA public TO gisedocuser;
ALTER DEFAULT PRIVILEGES IN SCHEMA public GRANT ALL ON TABLES TO gisedocuser;
ALTER DEFAULT PRIVILEGES IN SCHEMA public GRANT ALL ON SEQUENCES TO gisedocuser;
