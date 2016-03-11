namespace MiniprojektRAM.Migrations
{
    using MiniprojektRAM.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MiniprojektRAM.DataAccessLayer.ItemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MiniprojektRAM.DataAccessLayer.ItemContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.QuestionCategory.AddOrUpdate(
             new QuestionCategory { Id = 1, CatName="Bild"},
             new QuestionCategory { Id = 2, CatName = "Skiljetecken" },
             new QuestionCategory { Id = 3, CatName = "Färg" },
             new QuestionCategory { Id = 4, CatName = "Ordmängd" }
           );

            context.Question.AddOrUpdate(
              new Question { Id = 1, cId = 1, QuestionText = "Documentation/MiniprojektRAM.png", AnswerText="Klassdiagram" },
              new Question { Id = 2, cId = 2, QuestionText = "skilje*tecken", AnswerText = "skilje-tecken" },
              new Question { Id = 3, cId = 3, QuestionText = "Blå", AnswerText = "Blå" },
              new Question { Id = 4, cId = 4, QuestionText = "hej, svejs, i, lingon, skogen", AnswerText = "hej svejs i lingonskogen" },
              new Question { Id = 5, cId = 1, QuestionText = "Documentation/MiniprojektRAM.png", AnswerText="Klassdiagram2" },
              new Question { Id = 6, cId = 2, QuestionText = "skilje*tecken*2", AnswerText = "skilje-tecken-2" },
              new Question { Id = 7, cId = 3, QuestionText = "Blå2", AnswerText = "Blå2" },
              new Question { Id = 8, cId = 4, QuestionText = "hej, svejs, i, lingon, skogen 2", AnswerText = "hej svejs i lingonskogen 2" },
              new Question { Id = 9, cId = 1, QuestionText = "Documentation/MiniprojektRAM.png", AnswerText="Klassdiagram3" },
              new Question { Id = 10, cId = 2, QuestionText = "skilje*tecken*3", AnswerText = "skilje-tecken-3" },
              new Question { Id = 11, cId = 3, QuestionText = "Blå3", AnswerText = "Blå3" },
              new Question { Id = 12, cId = 4, QuestionText = "hej, svejs, i, lingon, skogen 3", AnswerText = "hej svejs i lingonskogen 3" }
            );

        }
    }
}
