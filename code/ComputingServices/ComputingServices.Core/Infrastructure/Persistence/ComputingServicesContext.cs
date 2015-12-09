using ComputingServices.Core.Domain.Models.CertainSportAbilityTest;
using ComputingServices.Core.Domain.Models.IQTest;
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
        private DbSet<PersonalityTestQuestionChoiceScore> PersonalityTestQuestionChoiceScores { get; set; }
        public DbSet<PersonalityTestElementStandardParametersSet> PersonalityTestElementStandardParametersSets { get; set; }
        private DbSet<PersonalityTestElementStandardParameter> PersonalityTestElementStandardParameters { get; set; }
        public DbSet<IQTestQuestionsSet> IQTestQuestionsSets { get; set; }
        private DbSet<IQTestQuestion> IQTestQuestions { get; set; }
        public DbSet<IQTestStandardParametersSet> IQTestStandardParametersSets { get; set; }
        private DbSet<IQTestStandardParameter> IQTestStandardParameters { get; set; }
        public DbSet<CertainSportAbilityTestEvaluationCriteriaSport> CertainSportAbilityTestEvaluationCriteriaSports { get; set; }
        private DbSet<CertainSportAbilityTestEvaluationCriteriaSportParameter> CertainSportAbilityTestEvaluationCriteriaSportParameters { get; set; }
        public DbSet<CertainSportAbilityTestEvaluationCriteriaSubSport> CertainSportAbilityTestEvaluationCriteriaSubSports { get; set; }
        public DbSet<CertainSportAbilityTestEvaluationCriteriaSubSportParametersSet> CertainSportAbilityTestEvaluationCriteriaSubSportParametersSets { get; set; }
        private DbSet<CertainSportAbilityTestEvaluationCriteriaSubSportParameter> CertainSportAbilityTestEvaluationCriteriaSubSportParameters { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersonalityTestQuestionsSet>().Property(type => type.Code).IsRequired();
            modelBuilder.Entity<PersonalityTestQuestionsSet>().HasMany(type => type.Questions).WithRequired();

            modelBuilder.Entity<PersonalityTestQuestion>().Ignore(type => type.Element);
            modelBuilder.Entity<PersonalityTestQuestion>().Property(type => type.ElementString).IsRequired().HasColumnName("Element");
            modelBuilder.Entity<PersonalityTestQuestion>().HasMany(type => type.ChoiceScores).WithRequired();

            modelBuilder.Entity<PersonalityTestQuestionChoiceScore>().Property(type => type.Choice).IsRequired();

            modelBuilder.Entity<PersonalityTestElementStandardParametersSet>().Property(type => type.Name).IsRequired();
            modelBuilder.Entity<PersonalityTestElementStandardParametersSet>().Ignore(type => type.Gender);
            modelBuilder.Entity<PersonalityTestElementStandardParametersSet>().Property(type => type.GenderString).IsRequired().HasColumnName("Gender");
            modelBuilder.Entity<PersonalityTestElementStandardParametersSet>().HasMany(type => type.Parameters).WithRequired();

            modelBuilder.Entity<PersonalityTestElementStandardParameter>().Ignore(type => type.Element);
            modelBuilder.Entity<PersonalityTestElementStandardParameter>().Property(type => type.ElementString).IsRequired().HasColumnName("Element");
            modelBuilder.Entity<PersonalityTestElementStandardParameter>().HasMany(type => type.Segments).WithRequired();

            modelBuilder.Entity<IQTestQuestionsSet>().Property(type => type.Code).IsRequired();
            modelBuilder.Entity<IQTestQuestionsSet>().HasMany(type => type.Questions).WithRequired();

            modelBuilder.Entity<IQTestQuestion>().Property(type => type.Group).IsRequired();
            modelBuilder.Entity<IQTestQuestion>().Property(type => type.CorrectChoice).IsRequired();

            modelBuilder.Entity<IQTestStandardParametersSet>().HasMany(type => type.Parameters).WithRequired();

            modelBuilder.Entity<CertainSportAbilityTestEvaluationCriteriaSport>().Property(type => type.Code).IsRequired();
            modelBuilder.Entity<CertainSportAbilityTestEvaluationCriteriaSport>().Property(type => type.Name).IsRequired();
            modelBuilder.Entity<CertainSportAbilityTestEvaluationCriteriaSport>().HasMany(type => type.Parameters).WithRequired();

            modelBuilder.Entity<CertainSportAbilityTestEvaluationCriteriaSportParameter>().Property(type => type.Level).IsRequired();
            modelBuilder.Entity<CertainSportAbilityTestEvaluationCriteriaSportParameter>().Ignore(type => type.Gender);
            modelBuilder.Entity<CertainSportAbilityTestEvaluationCriteriaSportParameter>().Property(type => type.GenderString).HasColumnName("Gender");

            modelBuilder.Entity<CertainSportAbilityTestEvaluationCriteriaSubSport>().Property(type => type.Code).IsRequired();
            modelBuilder.Entity<CertainSportAbilityTestEvaluationCriteriaSubSport>().Property(type => type.Name).IsRequired();
            modelBuilder.Entity<CertainSportAbilityTestEvaluationCriteriaSubSport>().HasRequired(type => type.Sport);
            modelBuilder.Entity<CertainSportAbilityTestEvaluationCriteriaSubSport>().Ignore(type => type.DataType);
            modelBuilder.Entity<CertainSportAbilityTestEvaluationCriteriaSubSport>().Property(type => type.DataTypeString).IsRequired().HasColumnName("DataType");
            modelBuilder.Entity<CertainSportAbilityTestEvaluationCriteriaSubSport>().Ignore(type => type.ComparePattern);
            modelBuilder.Entity<CertainSportAbilityTestEvaluationCriteriaSubSport>().Property(type => type.ComparePatternString).IsRequired().HasColumnName("ComparePattern");

            modelBuilder.Entity<CertainSportAbilityTestEvaluationCriteriaSubSportParametersSet>().Ignore(type => type.Gender);
            modelBuilder.Entity<CertainSportAbilityTestEvaluationCriteriaSubSportParametersSet>().Property(type => type.GenderString).HasColumnName("Gender");
            modelBuilder.Entity<CertainSportAbilityTestEvaluationCriteriaSubSportParametersSet>().HasRequired(type => type.SubSport);
            modelBuilder.Entity<CertainSportAbilityTestEvaluationCriteriaSubSportParametersSet>().HasMany(type => type.Parameters).WithRequired();

            modelBuilder.Entity<CertainSportAbilityTestEvaluationCriteriaSubSportParameter>().Property(type => type.OriginalValue).IsRequired();
        }
    }
}
