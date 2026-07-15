using static Seralyth.Menu.Main;
using Seralyth.Classes.Menu;
using Seralyth.Mods;
using UnityEngine;
using Seralyth.Managers;
using Seralyth.Menu;
using GorillaLocomotion;
namespace SeralythPlugin
{
    public class Plugin
    {
        public static string Name = "Example Plugin";
        public static string Description = "An example plugin used for testing.";

        public static void OnEnable()
        {
            LogManager.Log("Plugin " + Name + " has been enabled!");

            int category = Buttons.AddCategory("Plugin Mods");
            Buttons.AddButton(Buttons.GetCategory("Main"), new ButtonInfo { buttonText = "Plugin Mods", method = () => Buttons.CurrentCategoryIndex = category, isTogglable = false, toolTip = "Brings you to a category for plugins." });

            Buttons.AddButtons(
                category,
                new ButtonInfo[]
                {
                    new ButtonInfo { buttonText = "Exit Plugin Mods", method =() => Buttons.CurrentCategoryName = "Main", isTogglable = false, toolTip = "Returns you back to the main page." },
                    new ButtonInfo { buttonText = "Right Trigger Fly <color=grey>[</color><color=green>RT</color><color=grey>]</color>", method = () => RightTriggerFly(), toolTip = "Hold right trigger to fly." },


                }
            );
        }

        public static void OnDisable()
        {
            LogManager.Log("Plugin " + Name + " has been disabled!");

            Buttons.RemoveCategory("Plugin Mods");
            Buttons.RemoveButton(Buttons.GetCategory("Main"), "Plugin Mods");
        }



        private static void RightTriggerFly()
        {
            if (rightTrigger > 0.5f)
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaTagger.Instance.headCollider.transform.forward * Time.deltaTime * Movement.FlySpeed;
                GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            }
        }


        public static void OnGUI() { }

    }
}
