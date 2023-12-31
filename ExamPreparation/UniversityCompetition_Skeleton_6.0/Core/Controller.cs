﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        public Controller()
        {
            Subjects = new();
            Students = new();
            Universities = new();
        }

        private SubjectRepository subjects;

        public SubjectRepository Subjects
        {
            get { return subjects; }
            set { subjects = value; }
        }

        private StudentRepository students;

        public StudentRepository Students
        {
            get { return students; }
            set { students = value; }
        }
        private UniversityRepository universities;

        public UniversityRepository Universities
        {
            get { return universities; }
            set { universities = value; }
        }



        public string AddStudent(string firstName, string lastName)
        {
            int iD = students.Models.Count + 1;
            string fullName = firstName + " " + lastName;
            if (students.FindByName(fullName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }
            Student student = new(iD, firstName, lastName);
            students.AddModel(student);
            return string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, students.GetType().Name);
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            int iD = subjects.Models.Count + 1;
            if (subjectType != "TechnicalSubject" && subjectType != "EconomicalSubject" && subjectType != "HumanitySubject")
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }
            else if (subjects.FindByName(subjectName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }
            switch (subjectType)
            {
                case "TechnicalSubject":
                    TechnicalSubject technicalSubject = new(iD, subjectName);
                    subjects.AddModel(technicalSubject);
                    break;
                case "EconomicalSubject":
                    EconomicalSubject economical = new(iD, subjectName);
                    subjects.AddModel(economical);
                    break;
                case "HumanitySubject":
                    HumanitySubject humanity = new(iD, subjectName);
                    subjects.AddModel(humanity);
                    break;
            }
            return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, subjects.GetType().Name);
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            int iD = universities.Models.Count + 1;
            if (universities.FindByName(universityName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }
            List<int> subjectsId = new();
            List<ISubject> subjectsInUniversity = new();
            foreach (var item in requiredSubjects)
            {
                subjectsInUniversity.Add(subjects.FindByName(item));
            }
            foreach (var item in subjectsInUniversity)
            {
                subjectsId.Add(item.Id);
            }
            University university = new(iD, universityName, category, capacity, subjectsId);
            universities.AddModel(university);
            return string.Format(OutputMessages.UniversityAddedSuccessfully, universityName, universities.GetType().Name);
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string[] fullName = studentName
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            IStudent studentToApply = students.FindByName(studentName);
            IUniversity universityToJoin = universities.FindByName(universityName);
            if (studentToApply == null)
            {
                return string.Format(OutputMessages.StudentNotRegitered, fullName[0], fullName[1]);
            }
            else if (universityToJoin == null)
            {
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }
            else if (studentToApply.University == universityToJoin)
            {
                return string.Format(OutputMessages.StudentAlreadyJoined, fullName[0], fullName[1], universityName);
            }
            else if (universityToJoin.RequiredSubjects.All(x => studentToApply.CoveredExams.Contains(x)) == false)
            {
                return string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
            }
            studentToApply.JoinUniversity(universityToJoin);
            return string.Format(OutputMessages.StudentSuccessfullyJoined, fullName[0], fullName[1],universityName);
        }

        public string TakeExam(int studentId, int subjectId)
        {
            IStudent currentStudent = students.FindById(studentId);
            ISubject currentSubject = subjects.FindById(subjectId);
            if (currentStudent == null)
            {
                return OutputMessages.InvalidStudentId;
            }
            else if (currentSubject == null)
            {
                return OutputMessages.InvalidSubjectId;
            }
            else if (currentStudent.CoveredExams.Contains(currentSubject.Id))
            {
                return string.Format(OutputMessages.StudentAlreadyCoveredThatExam, currentStudent.FirstName, currentStudent.LastName, currentSubject.Name);
            }
            currentStudent.CoverExam(currentSubject);
            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam, currentStudent.FirstName, currentStudent.LastName, currentSubject.Name);

        }

        public string UniversityReport(int universityId)
        {
            IUniversity universityToReport = universities.FindById(universityId);
            List<IStudent> registeredStudents = students.Models.Where(x => x.University == universityToReport).ToList();
            
            StringBuilder sb = new();
            sb.AppendLine($"*** {universityToReport.Name} ***");
            sb.AppendLine($"Profile: {universityToReport.Category}");
            sb.AppendLine($"Students admitted: {registeredStudents.Count}");
            sb.AppendLine($"University vacancy: {universityToReport.Capacity-registeredStudents.Count}");
            return sb.ToString().Trim();
        }
    }
}
