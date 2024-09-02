
	CREATE TABLE Users (
		id INT PRIMARY KEY IDENTITY(1,1),
		name VARCHAR(255) NOT NULL,
		email VARCHAR(255) UNIQUE NOT NULL,
		password VARCHAR(255) NOT NULL
	);


	CREATE TABLE Blogs (
		id INT PRIMARY KEY IDENTITY(1,1),
		title VARCHAR(255) NOT NULL,
		content TEXT NOT NULL,
		state_id INT,
		created_at DATE ,
		updated_at DATE ,
		published_at DATE NULL,
		created_by_id INT,
		updated_by_id INT,
		ispublish BIT, -- 'BIT' is the type used for boolean values in MSSQL
		cover_picture VARBINARY(MAX), -- To store the path/URL of the cover picture
		FOREIGN KEY (created_by_id) REFERENCES Users(id),
		FOREIGN KEY (updated_by_id) REFERENCES Users(id)
	);

	CREATE TABLE Questions (
		id INT PRIMARY KEY IDENTITY(1,1),
		question TEXT NOT NULL,
		option_a VARCHAR(255) NOT NULL,
		option_b VARCHAR(255) NOT NULL,
		option_c VARCHAR(255) NOT NULL,
		option_d VARCHAR(255) NOT NULL,
		correct_option CHAR(1) NOT NULL, -- a, b, c, or d
		created_at DATE ,
		updated_at DATE ,
		published_at DATE NULL,
		created_by_id INT,
		updated_by_id INT,
		ispublish BIT, -- 'BIT' is the type used for boolean values in MSSQL
		FOREIGN KEY (created_by_id) REFERENCES Users(id),
		FOREIGN KEY (updated_by_id) REFERENCES Users(id),
	);

	CREATE TABLE MCQs (
		id INT PRIMARY KEY IDENTITY(1,1),
		title VARCHAR(255) NOT NULL,
		created_at DATE ,
		updated_at DATE ,
		published_at DATE NULL,
		created_by_id INT,
		updated_by_id INT,
		ispublish BIT, -- 'BIT' is the type used for boolean values in MSSQL
		FOREIGN KEY (created_by_id) REFERENCES Users(id),
		FOREIGN KEY (updated_by_id) REFERENCES Users(id)
	);

	CREATE TABLE MCQ_Questions (
		id INT PRIMARY KEY IDENTITY(1,1),
		mcq_id INT NOT NULL,
		question_id INT NOT NULL,
		FOREIGN KEY (mcq_id) REFERENCES MCQs(id),
		FOREIGN KEY (question_id) REFERENCES Questions(id)
	);

	CREATE TABLE Lessons (
		id INT PRIMARY KEY IDENTITY(1,1),
		title VARCHAR(255) NOT NULL,
		[description] TEXT,
		cover_picture VARBINARY(MAX),
		content TEXT NOT NULL,
		youtube_video VARCHAR(255) NOT NULL,
		created_at DATE ,
		updated_at DATE ,
		published_at DATE NULL,
		created_by_id INT,
		updated_by_id INT,
		ispublish BIT, -- 'BIT' is the type used for boolean values in MSSQL
		FOREIGN KEY (created_by_id) REFERENCES Users(id),
		FOREIGN KEY (updated_by_id) REFERENCES Users(id),
	);
