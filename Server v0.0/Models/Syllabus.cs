﻿namespace Server_v0._0.Models
{
    public class Syllabus
    {
        public int SyllabusId { get; set; }
        public int Grade { get; set; }
        public int StudId { get; set; }
        public Student Student { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
