using System;

public class ExamResult
{
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (maxGrade < minGrade)
        {
            throw new ArgumentOutOfRangeException("The min grade cannot be bigger than max grade.");
        }
        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade 
    {
        get { return this.grade; }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("The grade cannot be less than zero.");
            }

            this.grade = value;
        }
    }    
  
    public int MinGrade
    {
        get { return this.minGrade; }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("The min grade cannot be less than zero.");
            }

            this.minGrade = value;
        }
    }    

    public int MaxGrade
    {
        get { return this.maxGrade; }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("The max grade cannot be less than zero.");
            }

            this.maxGrade = value;
        }
    }    

    public string Comments
    {
        get { return this.comments; }

        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("The comments cannot be null or empty.");
            }

            this.comments = value;
        }
    }    
}
