CREATE DATABASE final_se;

USE final_se;


--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
																	--- TABLES ---
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------


-- User Table
CREATE TABLE users (
    user_id VARCHAR(50) PRIMARY KEY, 
    name VARCHAR(50), 
    password VARCHAR(50),
	
);

-- Degree Form Table
CREATE TABLE Degree_form (
    form_id VARCHAR(50) PRIMARY KEY, 
    name VARCHAR(50), 
	father_name VARCHAR(50), 
    present_address VARCHAR(50),
	permanent_address VARCHAR(50),
    email VARCHAR(50),
    CNIC VARCHAR(50),
    phone_no varchar(50),
    submission_date DATE,
	bank_challan_no INT,
    user_id VARCHAR(50), 
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);



-- Complaint Form Table
CREATE TABLE complaint_form (
    form_id VARCHAR(50) PRIMARY KEY, 
	[name] varchar(50),
    [description] VARCHAR(255), 
    submission_date DATE,
    [user_id] VARCHAR(50), 
    FOREIGN KEY ([user_id]) REFERENCES users([user_id])
);




-- Degree Issuance Token Table
CREATE TABLE TokenDeg (
    Token_id VARCHAR(50) PRIMARY KEY, 
    form_id VARCHAR(50), 
	-- no need for overall status and we can use AND condition with both the flags to get overall status value

    fyp_decision VARCHAR(20) CHECK (fyp_decision IN ('accepted', 'rejected', 'pending')),
    finance_decision VARCHAR(20) CHECK (finance_decision IN ('accepted', 'rejected', 'pending')),
    fyp_comment VARCHAR(255),
    finance_comment VARCHAR(255),
    FOREIGN KEY (form_id) REFERENCES Degree_form(form_id)
);



-- Token Date Time Table
CREATE TABLE Token_DateTime (
    Token_id VARCHAR(50), 
    starting_time TIME, 
    estimated_time TIME, 
    generation_date DATE,
    fyp_time TIME,
    finance_time TIME,
    FOREIGN KEY (Token_id) REFERENCES TokenDeg(Token_id)
);


-- Feedback Table
CREATE TABLE feedback (
    Feed_ID VARCHAR(50) PRIMARY KEY, 
    Deg_Tokenid VARCHAR(50), 
    comment VARCHAR(255),
    user_id VARCHAR(50), 
    FOREIGN KEY (Deg_Tokenid) REFERENCES TokenDeg(Token_id),
    
); 



-- Payment Table
CREATE TABLE Payment (
    Pay_id VARCHAR(50) PRIMARY KEY, 
    user_id VARCHAR(50), 
    status VARCHAR(20) CHECK (status IN ('Paid', 'Unpaid')),
    type VARCHAR(20) CHECK (type IN ('Processing Fee', 'Degree Fee')),
    Total_Amount DECIMAL(10, 2), 
    Paid_Amount DECIMAL(10, 2),
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);




--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
 -------------------------------------------------------------------------------------------------------------------------------------------------------------------------
																	--- TABLE INSERTIONS ---
 -------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------



-- Inserting sample data into the user table
INSERT INTO users (user_id, name, password)
VALUES 
    ('STU_01', 'ALI UMER', 'p1' ),
    ('ONE_01', 'Abdullah Masood', 'o1'),
    ('FIN_01', 'Tayyab Sohail', 'fi1'),
    ('FYP_01', 'Daniyal Kaleem', 'fy1'),
    ('DIR_01', 'Abtaal Aatif', 'd1'),
    ('STU_02', 'UMAIR Khalid', 'p2'),
	('STU_03', 'Abdullah Khan', 'p3' ),
	('STU_04', 'Ayesha Naeem', 'p4' ),
	('STU_05', 'Tajiya Darain', 'p5' ),
	('STU_06', 'Ali Raza', 'p6' );


INSERT INTO Degree_form (form_id, name, father_name,present_address, permanent_address , email, CNIC, phone_no, submission_date, bank_challan_no ,  user_id)
VALUES 
('DEG_01', 'ALI UMER', 'UMER Hayat' ,'Bahria Phase 8 Rawalpindi', 'Mandi Bahudin' , 'i210380@nu.edu.pk', '1234567890234', '123456789' , '2024-04-17','12345' ,'STU_01'),
('DEG_02', 'Umair Khalid', 'Khalid' ,'Morgah', 'Faisalabad' , 'i210455@nu.edu.pk', '9876543322', '123456789' , '2024-05-17','12343335' ,'STU_02'),
('DEG_03', 'Abdullah Khan', 'Kashif Ali Khan' ,'Phase 7 Islamabad', 'Attock' , 'p20001@nu.edu.pk', '1234567890234', '123456789' , '2024-04-29','12322245' ,'STU_03'),
('DEG_04', 'Ayesha Naeem', 'Naeem' ,'Bahria Phase 8 Rawalpindi', 'Mandi Bahudin' , 'i21110@nu.edu.pk', '1234567890234', '123456789' , '2023-01-16','12399945' ,'STU_04');


INSERT INTO TokenDeg (Token_id, form_id, fyp_decision, finance_decision, fyp_comment, finance_comment)
VALUES 
('TOK_01', 'DEG_01', 'accepted', 'accepted', 'The decision is accepted', 'The decision is accepted'),
('TOK_02', 'DEG_02', 'accepted', 'pending', 'The decision is accepted', 'The decision is still pending'),
('TOK_03', 'DEG_03', 'pending', 'accepted', 'The decision is still pending', 'The decision is accepted'),
('TOK_04', 'DEG_04', 'accepted', 'pending', 'The decision is accepted', 'The decision is still pending');


INSERT INTO Token_DateTime (Token_id, starting_time, estimated_time, generation_date, fyp_time, finance_time)
VALUES 
    ('TOK_01', '13:00:00.000', '10:00:00.000', '2024-04-29', '18:30:00.123', '14:30:00.000'),
    ('TOK_02', '13:00:00.000', '12:00:00.000', '2024-04-29', '09:45:00.456', '16:45:00.000'),
    ('TOK_03', '13:00:00.000', '13:30:00.000', '2024-05-01', '23:15:00.789', '11:15:00.000'),
    ('TOK_04', '13:00:00.000', '15:00:00.000', '2024-05-02', '00:00:00.111', '09:00:00.000');


INSERT INTO Payment (Pay_id, user_id, status, type, Total_Amount, Paid_Amount)
VALUES 
    ('PAY_01', 'STU_01', 'Paid', 'Processing Fee', 3000.00, 3000.00),
    ('PAY_02', 'STU_01', 'Paid', 'Degree Fee', 5000.00, 5000.00),
	
	('PAY_03', 'STU_02', 'Paid', 'Processing Fee', 3000.00, 3000.00),
    ('PAY_04', 'STU_02', 'Paid', 'Degree Fee', 5000.00, 5000.00),
	
	('PAY_05', 'STU_03', 'Paid', 'Processing Fee', 3000.00, 3000.00),
	('PAY_06', 'STU_03', 'Paid', 'Degree Fee', 5000.00, 5000.00),

	('PAY_07', 'STU_04', 'Paid', 'Processing Fee', 3000.00, 3000.00),
	('PAY_08', 'STU_04', 'Paid', 'Degree Fee', 5000.00, 5000.00),

	('PAY_09', 'STU_05', 'Paid', 'Processing Fee', 3000.00, 3000.00),
	('PAY_10', 'STU_05', 'Paid', 'Degree Fee', 5000.00, 5000.00),


	('PAY_11', 'STU_06', 'Paid', 'Processing Fee', 3000.00, 3000.00),
	('PAY_12', 'STU_06', 'Paid', 'Degree Fee', 5000.00, 5000.00);


	-- Inserting values into the complaint_form table
INSERT INTO complaint_form (form_id, description, submission_date, user_id)
VALUES ('COM_03', 'EXPECTATIONS NOT MET', '2024-04-13', 'STU_03');

INSERT INTO complaint_form (form_id, description, submission_date, user_id)
VALUES ('COM_01', 'FEE CHARGES TOO HIGH', '2024-04-10', 'STU_01');

INSERT INTO complaint_form (form_id, description, submission_date, user_id)
VALUES ('COM_02', 'HATED UNI LIFE', '2024-04-03', 'STU_01');



-- Insert data into the feedback table
INSERT INTO feedback (Feed_ID, Deg_Tokenid, comment, user_id) VALUES ('FEED_03', 'TOK_03', 'FEE CHARGES TOO HIGH', 'STU_03');
INSERT INTO feedback (Feed_ID, Deg_Tokenid, comment, user_id) VALUES ('FEED_01', 'TOK_01', 'HATED UNI LIFE', 'STU_01');
INSERT INTO feedback (Feed_ID, Deg_Tokenid, comment, user_id) VALUES ('FEED_02', 'TOK_01', 'EXPECTATIONS', 'STU_02');
