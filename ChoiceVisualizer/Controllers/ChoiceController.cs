using KitProjects.ChoiceVisualizer.Models;
using KitProjects.EnterpriseLibrary.Core.Models.Films;
using KitProjects.FileSystemChoicePreparation.PrepareFilmChoices;
using Medallion;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace KitProjects.ChoiceVisualizer.Controllers
{
    public class FilmChoiceController : Controller
    {
        public IActionResult Prepare()
        {
            var command = new PrepareFilmChoicesCommand();
            var choices = command.Execute(new PrepareFilmChoicesCommandArgs(@"C:\Users\admin\Pictures\ChoiceVisualizer"));
            if (choices.Length >= 64)
                choices = choices.Shuffled().Take(64).ToArray();
            else if (choices.Length >= 32 && choices.Length < 64)
                choices = choices.Shuffled().Take(32).ToArray();
            else
                choices = choices.Shuffled().Take(16).ToArray();

            choices.Shuffle();
            var cards = choices.Select(choice => new Card<FilmChoice>
            {
                Choice = choice,
                Selected = false
            });
            var firstHalf = cards.Skip(0).Take(choices.Length / 2).ToList();
            var secondHalf = cards.Skip(choices.Length / 2).Take(choices.Length / 2).ToList();
            var viewModel = new RoundViewModel
            {
                FirstHalf = firstHalf,
                SecondHalf = secondHalf
            };

            return View("Round", viewModel);
        }

        [DisableRequestSizeLimit]
        public IActionResult Round(RoundViewModel round)
        {
            if (round.FirstHalf.Count > 4)
            {
                var viewModel = new RoundViewModel
                {
                    FirstHalf = round.FirstHalf.Where(choice => choice.Selected).ToList(),
                    SecondHalf = round.SecondHalf.Where(choice => choice.Selected).ToList()
                };
                NullifySelection(viewModel.FirstHalf);
                NullifySelection(viewModel.SecondHalf);

                return View("Round", viewModel);
            }

            var semiFinalsViewModel = new SemiFinalsViewModel
            {
                FirstPair = round.FirstHalf.Where(choice => choice.Selected).ToList(),
                SecondPair = round.SecondHalf.Where(choice => choice.Selected).ToList()
            };
            NullifySelection(semiFinalsViewModel.FirstPair);
            NullifySelection(semiFinalsViewModel.SecondPair);

            return View("SemiFinals", semiFinalsViewModel);
        }

        [DisableRequestSizeLimit]
        public IActionResult SemiFinals(SemiFinalsViewModel semiFinals)
        {
            var first = semiFinals.FirstPair.First(choice => choice.Selected);
            var second = semiFinals.SecondPair.First(choice => choice.Selected);
            var thirdPlace = new List<Card<FilmChoice>>
            {
                semiFinals.FirstPair.First(choice => choice.Selected == false),
                semiFinals.SecondPair.First(choice => choice.Selected == false)
            };
            first.Selected = false;
            second.Selected = false;
            NullifySelection(thirdPlace);

            return View("Finals", new FinalsViewModel
            {
                First = first,
                Second = second,
                ThirdPlaceContestants = thirdPlace
            });
        }

        [DisableRequestSizeLimit]
        public IActionResult Finals(FinalsViewModel finals)
        {
            var viewModel = new ResultsViewModel
            {
                ThirdPlace = finals.ThirdPlaceContestants.First(contestant => contestant.Selected)
            };
            if (finals.First.Selected)
            {
                viewModel.Winner = finals.First;
                viewModel.SecondPlace = finals.Second;
            }
            else
            {
                viewModel.Winner = finals.Second;
                viewModel.SecondPlace = finals.First;
            }
            return View("Results", viewModel);
        }

        private static void NullifySelection(IEnumerable<Card<FilmChoice>> choices)
        {
            foreach (var choice in choices)
            {
                choice.Selected = false;
            }
        }
    }
}
