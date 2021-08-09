CREATE SCHEMA nano;

CREATE TABLE nano."Surveys"(
    "Id" INT NOT NULL GENERATED ALWAYS AS IDENTITY,
    "SurveyName" TEXT NOT NULL,
    PRIMARY KEY ("Id")
);

CREATE INDEX SurveysIdIndex ON nano."Surveys"("Id");

CREATE TABLE nano."Questions"(
    "Id" INT NOT NULL GENERATED ALWAYS AS IDENTITY,
    "QuestionText" TEXT NOT NULL,
    PRIMARY KEY ("Id")
);

CREATE INDEX QuestionIdIndex ON nano."Questions"("Id");

CREATE TABLE nano."SurveysQuestions" (
    "SurveyId" INT NOT NULL,
    "QuestionId" INT NOT NULL,
    PRIMARY KEY ("SurveyId", "QuestionId"),
    FOREIGN KEY ("SurveyId") REFERENCES nano."Surveys"("Id"),
    FOREIGN KEY ("QuestionId") REFERENCES nano."Questions"("Id")
);

CREATE TABLE nano."Answers"(
    "Id" INT NOT NULL GENERATED ALWAYS AS IDENTITY,
    "AnswerText" TEXT NOT NULL,
    PRIMARY KEY ("Id")
);

CREATE INDEX AnswersIdIndex ON nano."Answers"("Id");

CREATE TABLE nano."QuestionsAnswers"(
    "QuestionId" INT NOT NULL,
    "AnswerId" INT NOT NULL,
    PRIMARY KEY ("QuestionId", "AnswerId"),
    FOREIGN KEY ("QuestionId") REFERENCES nano."Questions"("Id"),
    FOREIGN KEY ("AnswerId") REFERENCES nano."Answers"("Id")
);

CREATE TABLE nano."Interviews"(
    "Id" INT NOT NULL GENERATED ALWAYS AS IDENTITY,
    "UserId" INT NOT NULL,
    PRIMARY KEY ("Id")
);

CREATE INDEX InterviewsIdIndex ON nano."Interviews"("Id");

CREATE TABLE nano."Results"(
    "Id" INT NOT NULL GENERATED ALWAYS AS IDENTITY,
    "InterviewId" INT NOT NULL,
    "QuestionId" INT NOT NULL,
    "AnswerId" INT NOT NULL,
    PRIMARY KEY ("Id"),
    FOREIGN KEY ("InterviewId") REFERENCES nano."Interviews"("Id"),
    FOREIGN KEY ("QuestionId") REFERENCES nano."Questions"("Id"),
    FOREIGN KEY ("AnswerId") REFERENCES nano."Answers"("Id")
);
