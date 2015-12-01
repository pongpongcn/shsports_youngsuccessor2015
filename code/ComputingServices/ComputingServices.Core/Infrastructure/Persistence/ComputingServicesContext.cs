using ComputingServices.Core.Domain.Models.PersonalityTest;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace ComputingServices.Core.Infrastructure.Persistence
{
    public class ComputingServicesContext : DbContext
    {
        public DbSet<PersonalityTestQuestionsSet> PersonalityTestQuestionsSets { get; set; }
        private DbSet<PersonalityTestQuestion> PersonalityTestQuestions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersonalityTestQuestion>().Property(type => type.ElementString).HasColumnName("Element");

            modelBuilder.Entity<PersonalityTestQuestionsSet>().HasMany(type => type.Questions).WithRequired().WillCascadeOnDelete();

            modelBuilder.Entity<PersonalityTestQuestion>().HasMany(type => type.ChoiceScores).WithRequired().WillCascadeOnDelete();
        }
    }
}
