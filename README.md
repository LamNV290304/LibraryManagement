-- Create database
CREATE DATABASE Library;
GO

USE Library;
GO

-- Create tables
CREATE TABLE Publishers (
    publisher_id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL,
    address NVARCHAR(255),
    contact NVARCHAR(50)
);

CREATE TABLE Categories (
    category_id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL,
    description NVARCHAR(MAX)
);

CREATE TABLE Books (
    book_id INT IDENTITY(1,1) PRIMARY KEY,
    title NVARCHAR(255) NOT NULL,
    isbn NVARCHAR(13) NOT NULL UNIQUE,
    publisher_id INT,
    publication_year INT,
    category_id INT,
    total_copies INT NOT NULL,
    available_copies INT NOT NULL,
    price DECIMAL(10, 2),
    FOREIGN KEY (publisher_id) REFERENCES Publishers(publisher_id),
    FOREIGN KEY (category_id) REFERENCES Categories(category_id)
);

CREATE TABLE Authors (
    author_id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL,
    birthdate DATE,
    nationality NVARCHAR(50)
);

CREATE TABLE Book_Authors (
    book_id INT,
    author_id INT,
    PRIMARY KEY (book_id, author_id),
    FOREIGN KEY (book_id) REFERENCES Books(book_id),
    FOREIGN KEY (author_id) REFERENCES Authors(author_id)
);

CREATE TABLE Users (
    user_id INT IDENTITY(1,1) PRIMARY KEY,
    username NVARCHAR(100) NOT NULL,
    password NVARCHAR(100) NOT NULL,
    first_name NVARCHAR(100) NOT NULL,
    last_name NVARCHAR(100) NOT NULL,
    sex CHAR(1) CHECK (sex IN ('Male', 'Female')),
    email NVARCHAR(100) NOT NULL UNIQUE,
    phone NVARCHAR(20),
    address NVARCHAR(255),
    created_at DATE NOT NULL,
    role NVARCHAR(10) NOT NULL
);

CREATE TABLE Loans (
    loan_id INT IDENTITY(1,1) PRIMARY KEY,
    book_id INT,
    user_id INT,
    loan_date DATE NOT NULL,
    due_date DATE NOT NULL,
    return_date DATE,
    fine DECIMAL(10, 2) DEFAULT 0.00,
    overdue_days INT DEFAULT 0,
    staff_id INT,
    FOREIGN KEY (book_id) REFERENCES Books(book_id),
    FOREIGN KEY (user_id) REFERENCES Users(user_id),
    FOREIGN KEY (staff_id) REFERENCES Users(user_id)
);

CREATE TABLE Reservations (
    reservation_id INT IDENTITY(1,1) PRIMARY KEY,
    book_id INT,
    user_id INT,
    reservation_date DATE NOT NULL,
    status NVARCHAR(20) NOT NULL CHECK (status IN ('Processing', 'Success', 'Fail')),
    note NVARCHAR(MAX),
    FOREIGN KEY (book_id) REFERENCES Books(book_id),
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
);

