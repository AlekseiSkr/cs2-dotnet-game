using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace cs2_dotnet_game.States
{
    public class DialogBoxState : State
    {
        private DialogBox _dialogBox;
        private Texture2D backgroundTexture;

        public DialogBoxState(GameManager gm)
        {
            backgroundTexture = Globals.Content.Load<Texture2D>("intro");
            _dialogBox = new DialogBox
            {
                Text = "Welcome to 'Last Elves'! Press Enter to proceed, P to get back, and F to enter the game.\n" +
                   "In the magical realm of Stenden, the ancient elves have long lived in peace and harmony with nature. But a powerful curse has befallen their land, corrupting the once pristine forests and turning them into twisted, dangerous places. The world itself became a desolate wasteland.\n" +
                   "Facing the new reality, the elven kingdoms tried to come together and save their lands. Unknown to them however, the curse had been placed by a powerful yet corrupt wizard, leader of the orks, known only as the Stalker. One by one, the kingdoms fell into the darkness, or were twisted into becoming hideous orks. Now, all but one of the once mighty elves is still roaming the lands, and where great forests of green once stood, dark, blasphemous industrial plants toil away into the ages.\n" +
                   "You are the Nameless One, the great Archmage of an unknown age and a great inventor, the last surviving elf. You have swore a deadly oath, to avenge your people and cleanse the land of corruption and orks. Your arch nemesis, the Stalker, must be defeated.\n" +
                   "To stop the Stalker and avenge your people, you must first destroy his hordes of orks - powerful but not particularly bright, 25 of his legions march and terrorise what is left of the once fair land. Moreover, the Stalker's fortress is tightly locked behind mighty gates, that can be opened with 3 keys. These keys are safeguarded by his ork chieftains.\n" +
                   "Once you have weakened his influence, you must face the Stalker in a final showdown. But be wary, for he is no ordinary foe - he is a master of corruption, and he has many tricks up his sleeve. You'll need to use all of your skills and wits to defeat him, break the curse and finally be at peace.\n" +
                   "As you journey through the land, you'll meet a variety of side items and characters, some of whom may help you on your quest. You will have access to your safehouse at all times - far away from any inquisitive foes. It is from here you can rest, or spend the knowledge and experience gained battling the legion to upgrade your strength. Go now, and live up to the name of your ancestors! Good luck, hero."
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
            Globals.SpriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, 1920, 1080), Color.White);
            _dialogBox.Draw();
        }
    }
}
