using Microsoft.Xna.Framework.Input;

namespace cs2_dotnet_game.States
{
    public class DialogBoxState : State
    {
        private DialogBox _dialogBox;

        public DialogBoxState(GameManager gm)
        {
            _dialogBox = new DialogBox
            {
                Text = "Press Enter to proceed, P to get back, and F to enter the game.\n" +
                   "In the world of Arvandor, the ancient elves have long lived in peace and harmony with nature. But a powerful curse has befallen their land, corrupting the once pristine forests and turning them into twisted, dangerous places.\n" +
                   "The kingdom of Thundertree, one of the 4 major elven kingdom who makes up the world of Arvandor, has been in turmoil for years. A dark force has been plaguing the land, corrupting the once peaceful people and turning them into mindless, violent beasts. The king, desperate to save his people, has put out a call for adventurers to come to his aid.\n" +
                   "You are Zavix, the great Archmage of unknown age. It is known that you took part in the 2nd demon wars, but there is no record that mention you being in the first demon wars. You have been hailed as a hero, and anytime Arvandor is truely in peril you will always be there to help.\n" +
                   "You answering the call for help from the king, arrived in the city of Silvyrion, the final elven city of the kingdom of Thundertree to find a land on the brink of destruction. As you investigate, you discover that an evil sorcerer has been using a powerful magical artifact to control the minds of the creatures of the forest and bend them to his will.\n" +
                   "To stop the sorcerer, you must first find the artifact - a powerful amulet that is said to be hidden deep within a dungeon beneath the cursed forest. But the dungeon is filled with traps, puzzles, and deadly creatures, and the sorcerer's minions will do anything to stop you from finding the amulet.\n" +
                   "Once you have the amulet, you must face the wizard in a final showdown. But the wizard is no ordinary foe - he is a master of the dark arts, and he has many tricks up his sleeve. You'll need to use all of your skills and wits to defeat him, break the curse and finally restore peace to Thundertree.\n" +
                   "As you journey through the land, you'll meet a variety of other side items and characters, some of whom may join your party and help you on your quest. You'll explore ancient ruins, battle fierce monsters, and unravel the mysteries of the wizard's power. And at the end of it all, you'll be hailed as heroes - the saviors of elves of Thundertree and their home of Arvandor."
            };
            _dialogBox.Initialize();
        }

        public override void Update(GameManager gm)
        {
            _dialogBox.Update();
/*            if (InputManager.KeyState.IsKeyDown(Keys.O))
            {
                if (!_dialogBox.Active)
                {
                    _dialogBox = new DialogBox
                    {
                        Text = "New dialog box!\n" +
                                    "Press Enter to proceed and P to get back."
                    };
                    _dialogBox.Initialize();
                }
            }*/

            if (InputManager.KeyState.IsKeyDown(Keys.F) || !_dialogBox.Active)
            {
                gm.ChangeState(GameStates.Play);
            }
        }

        public override void Draw(GameManager gm)
        {
            _dialogBox.Draw();
        }
    }
}
