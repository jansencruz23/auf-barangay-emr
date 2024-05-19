using AUF.EMR.MVC.Models;

namespace AUF.EMR.MVC.Services
{
    public class ClassificationService
    {
        private List<Classification> _classifications;
        public ClassificationService()
        {
            _classifications = new()
            {
                new Classification
                {
                    Id = 1,
                    Key = "N",
                    Name = "N - Newborn",
                    Description = "0-28 days"
                },
                new Classification
                {
                    Id = 2,
                    Key = "I",
                    Name = "I - Infant",
                    Description = "29 days-11 months old"
                },
                new Classification
                {
                    Id = 3,
                    Key = "U",
                    Name = "U - Under-five ",
                    Description = "1-4 years old"
                },
                new Classification
                {
                    Id = 4,
                    Key = "S",
                    Name = "S - School-aged Children",
                    Description = "5-9 years old"
                },
                new Classification
                {
                    Id = 5,
                    Key = "A",
                    Name = "A - Adolescents",
                    Description = "10-19 years old"
                },
                new Classification
                {
                    Id = 6,
                    Key = "AH",
                    Name = "AH - Adult",
                    Description = "20-59 years old"
                },
                new Classification
                {
                    Id = 7,
                    Key = "SC",
                    Name = "SC - Senior Citizen",
                    Description = "60+ years old"
                },
                new Classification
                {
                    Id = 8,
                    Key = "WRA",
                    Name = "WRA - Women of Reproductive Age",
                    Description = "15-49 years old"
                },
                new Classification
                {
                    Id = 9,
                    Key = "AP",
                    Name = "AP - Adolescent-Pregnant",
                    Description = "10-19 years old"
                },
                new Classification
                {
                    Id = 10,
                    Key = "P",
                    Name = "P - Pregnant",
                    Description = ""
                },
                new Classification
                {
                    Id = 11,
                    Key = "PP",
                    Name = "PP - Post Partum",
                    Description = "Post Partum"
                },
                new Classification
                {
                    Id = 12,
                    Key = "PWD",
                    Name = "PWD - Person with Disability",
                    Description = ""
                }
            };
        }

        public List<Classification> GetClassifications()
        {
            return _classifications;
        }

        private List<Classification> GetDefaultClassification()
        {
            var newClassification = new List<Classification>();
            foreach (var classification in _classifications)
            {
                newClassification.Add(classification);
            }

            return newClassification;
        }

        public List<Classification> MapSelected(string classifications)
        {
            if (string.IsNullOrWhiteSpace(classifications))
            {
                return GetDefaultClassification();
            }

            var newClassifications = GetDefaultClassification();
            var keys = classifications.Split(",");
            foreach (var key in keys)
            {
                var classification = newClassifications.Find(c => c.Key.Equals(key));
                if (classification != null)
                {
                    classification.Selected = true;
                }
            }

            return newClassifications;
        }
    }
}
