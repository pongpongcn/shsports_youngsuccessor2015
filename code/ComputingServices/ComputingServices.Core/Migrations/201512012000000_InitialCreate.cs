namespace ComputingServices.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IQTestQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Group = c.String(nullable: false),
                        Code = c.Int(nullable: false),
                        CorrectChoice = c.String(nullable: false),
                        IQTestQuestionsSet_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IQTestQuestionsSets", t => t.IQTestQuestionsSet_Id, cascadeDelete: true)
                .Index(t => t.IQTestQuestionsSet_Id);
            
            CreateTable(
                "dbo.IQTestQuestionsSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IQTestStandardParameters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OriginalScore = c.Int(nullable: false),
                        IQ = c.Int(nullable: false),
                        IQTestStandardParametersSet_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IQTestStandardParametersSets", t => t.IQTestStandardParametersSet_Id, cascadeDelete: true)
                .Index(t => t.IQTestStandardParametersSet_Id);
            
            CreateTable(
                "dbo.IQTestStandardParametersSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AgeMin = c.Int(nullable: false),
                        AgeMax = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonalityTestElementStandardParameters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Element = c.String(nullable: false),
                        ParameterX = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ParameterS = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PersonalityTestElementStandardParametersSet_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonalityTestElementStandardParametersSets", t => t.PersonalityTestElementStandardParametersSet_Id, cascadeDelete: true)
                .Index(t => t.PersonalityTestElementStandardParametersSet_Id);
            
            CreateTable(
                "dbo.PersonalityTestElementStandardParametersSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        AgeMin = c.Int(nullable: false),
                        AgeMax = c.Int(nullable: false),
                        Gender = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonalityTestQuestionChoiceScores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Choice = c.String(nullable: false),
                        Score = c.Int(nullable: false),
                        PersonalityTestQuestion_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonalityTestQuestions", t => t.PersonalityTestQuestion_Id, cascadeDelete: true)
                .Index(t => t.PersonalityTestQuestion_Id);
            
            CreateTable(
                "dbo.PersonalityTestQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        Element = c.String(nullable: false),
                        PersonalityTestQuestionsSet_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonalityTestQuestionsSets", t => t.PersonalityTestQuestionsSet_Id, cascadeDelete: true)
                .Index(t => t.PersonalityTestQuestionsSet_Id);
            
            CreateTable(
                "dbo.PersonalityTestQuestionsSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonalityTestQuestions", "PersonalityTestQuestionsSet_Id", "dbo.PersonalityTestQuestionsSets");
            DropForeignKey("dbo.PersonalityTestQuestionChoiceScores", "PersonalityTestQuestion_Id", "dbo.PersonalityTestQuestions");
            DropForeignKey("dbo.PersonalityTestElementStandardParameters", "PersonalityTestElementStandardParametersSet_Id", "dbo.PersonalityTestElementStandardParametersSets");
            DropForeignKey("dbo.IQTestStandardParameters", "IQTestStandardParametersSet_Id", "dbo.IQTestStandardParametersSets");
            DropForeignKey("dbo.IQTestQuestions", "IQTestQuestionsSet_Id", "dbo.IQTestQuestionsSets");
            DropIndex("dbo.PersonalityTestQuestions", new[] { "PersonalityTestQuestionsSet_Id" });
            DropIndex("dbo.PersonalityTestQuestionChoiceScores", new[] { "PersonalityTestQuestion_Id" });
            DropIndex("dbo.PersonalityTestElementStandardParameters", new[] { "PersonalityTestElementStandardParametersSet_Id" });
            DropIndex("dbo.IQTestStandardParameters", new[] { "IQTestStandardParametersSet_Id" });
            DropIndex("dbo.IQTestQuestions", new[] { "IQTestQuestionsSet_Id" });
            DropTable("dbo.PersonalityTestQuestionsSets");
            DropTable("dbo.PersonalityTestQuestions");
            DropTable("dbo.PersonalityTestQuestionChoiceScores");
            DropTable("dbo.PersonalityTestElementStandardParametersSets");
            DropTable("dbo.PersonalityTestElementStandardParameters");
            DropTable("dbo.IQTestStandardParametersSets");
            DropTable("dbo.IQTestStandardParameters");
            DropTable("dbo.IQTestQuestionsSets");
            DropTable("dbo.IQTestQuestions");
        }
    }
}
