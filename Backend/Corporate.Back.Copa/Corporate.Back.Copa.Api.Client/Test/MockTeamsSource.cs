using Corporate.Back.Copa.Api.Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Corporate.Back.Copa.Api.Client.Test
{
    public class MockTeamsSource
    {
        public IEnumerable<TeamViewModel> GenEquipesTest()
        {
            List<TeamViewModel> list = new List<TeamViewModel>()
            {
                new TeamViewModel()
                {
                    Id = "cd8f6b48-97cf-48d8-ba62-7f1d52f39d33",
                    Name = "Equipe 5",
                    Initials = "EQP5",
                    Goals = 1
                },
                new TeamViewModel()
                {
                    Id = "cd8f6b48-97cf-48d8-ba62-7f1d62f39c12",
                    Name = "Equipe 4",
                    Initials = "EQP4",
                    Goals = 4
                },
                new TeamViewModel()
                {
                    Id = "cd8f6b48-97cf-48d8-ba62-6f1d42639c55",
                    Name = "Equipe 2",
                    Initials = "EQP2",
                    Goals = 4
                },
                new TeamViewModel()
                {
                    Id = "a90b4fd8-9860-44d1-9420-47d4ce5da52d",
                    Name = "Equipe 6",
                    Initials = "EQP6",
                    Goals = 5
                },
                new TeamViewModel()
                {
                    Id = "cd8f6b48-97cf-48d8-ba62-7f1d52f394ff",
                    Name = "Equipe 8",
                    Initials = "EQP8",
                    Goals = 0
                },
                new TeamViewModel()
                {
                    Id = "cd8f6b48-97cf-48d8-ba62-7f1d62f39a77",
                    Name = "Equipe 12",
                    Initials = "EQP12",
                    Goals = 1
                },
                new TeamViewModel()
                {
                    Id = "cd8f6b48-97cf-48d8-ba62-6f1d426394f2",
                    Name = "Equipe 14",
                    Initials = "EQP14",
                    Goals = 2
                },
                new TeamViewModel()
                {
                    Id = "a90b4fd8-9860-44d1-9420-47d4ce5dafde",
                    Name = "Equipe 16",
                    Initials = "EQP16",
                    Goals = 2
                }
            };
            return list;
        }

    }
}
