namespace NewsDB.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class New
    {
        public int Id { get; set; }

        [ConcurrencyCheck]
        public string Content { get; set; }
    }
}