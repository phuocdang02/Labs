# MMSOFT SCRIPTS - BUILD MOODLE WITH DOCKER

INSTRUCTIONS

1. Folder Structure:

   - template/
   - moodle/
   - docker-compose.yml
   - database/db.sql

2. Docker Compose Configuration:
   Improve readability and maintainability of your docker-compose.yml file:

```text
version: '3.8'

services:
  moodle:
    image: moodlehq/moodle-php-apache:8.0
    environment:
      MOODLE_DB_TYPE: mysqli
      MOODLE_DB_HOST: db
      MOODLE_DB_PORT: 3306
      MOODLE_DB_NAME: db_name
      MOODLE_DB_USER: db_user
      MOODLE_DB_PASS: db_pass
      MOODLE_ADMIN: <admin@moodle.com>
      MOODLE_ADMIN_PASSWORD: admin_password
      MOODLE_ADMIN_EMAIL: <admin@moodle.com>
    volumes:
      - ./moodle:/var/www/html/moodle
    ports:
      - "80:80"
    depends_on:
      - db

  db:
    image: mysql:8.0
    environment:
      MYSQL_ROOT_PASSWORD: root_password
      MYSQL_DATABASE: db_name
      MYSQL_USER: db_user
      MYSQL_PASSWORD: db_pass
    ports:
      - "6789:3306"
    volumes:
      - moodle-db-data:/var/lib/mysql

volumes:
  moodle-db-data:
```
