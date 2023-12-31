﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public class Student : IStudent
    {
        public Student(int studentId, string firstName, string lastName)
        {
            Id = studentId;
            FirstName = firstName;
            LastName = lastName;
            coveredExamsCopy = new();
            coveredExams = coveredExamsCopy;
        }
        private List<int> coveredExamsCopy;
        private string firstName;
        private string lastName;
        private IReadOnlyCollection<int> coveredExams;

        public int Id { get; private set; }

        public string FirstName 
        { 
            get => firstName; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get => lastName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                lastName = value;
            }
        }

        public IReadOnlyCollection<int> CoveredExams 
        { 
            get => coveredExams; 
            private set
            {
                coveredExams = coveredExamsCopy;
            }
        }

        public IUniversity University { get; private set; }

        public void CoverExam(ISubject subject)
        {
            coveredExamsCopy.Add(subject.Id);
        }

        public void JoinUniversity(IUniversity university)
        {
            University = university;
        }
    }
}
