create table Member(
	mNo int not null AUTO_INCREMENT, /* PK */
	mId varchar(30) not null,        /* 아이디 */
	mPass varchar(16) not null,      /* 비밀번호 */
	mName varchar(10) not null,      /* 사용자 이름 */
	delYn varchar(1) not null DEFAULT 'N',
	regDate DATETIME not null DEFAULT CURRENT_TIMESTAMP,
	modDate DATETIME not null DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY (`mNo`)
)
;

create table Notice(
	nNo int not null AUTO_INCREMENT, /* PK */
	mNo int not null,                /* FK 입력한 사용자  */
	nTitle varchar(30) not null,     /* 제목 */
	nContents varchar(200) not null, /* 내용 */
	delYn varchar(1) not null DEFAULT 'N',
	regDate DATETIME not null DEFAULT CURRENT_TIMESTAMP,
	modDate DATETIME not null DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY (`nNo`),
	INDEX FK_Notice_Member (mNo),
	CONSTRAINT FK_Notice_Member FOREIGN KEY (mNo) REFERENCES Member (mNo)
)
;