using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using LeagueSharp;
using LeagueSharp.Common;

namespace BlinkLag
{
    class Program
    {
        public static Menu Config;
        public static List<GameObject> wards = new List<GameObject>();
        private static Spell _Q = new Spell(SpellSlot.Q, 99999, TargetSelector.DamageType.Physical);
		private static Spell _W = new Spell(SpellSlot.W, 99999, TargetSelector.DamageType.Physical);
		private static Spell _E = new Spell(SpellSlot.E, 99999, TargetSelector.DamageType.Physical);
		private static Spell _R = new Spell(SpellSlot.R, 99999, TargetSelector.DamageType.Physical);
        static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += OnGameLoad;
        }



        private static void OnGameLoad(EventArgs args)
        {
            Config = new Menu("LAG", "Exploit", true);
            Config.AddSubMenu(new Menu("Exploit", "Exploit"));

            Config.SubMenu("Exploit").AddItem(new MenuItem("LAGQ", "Spam Q(LAG)")).SetValue(new KeyBind("G".ToCharArray()[0], KeyBindType.Toggle));
			Config.SubMenu("Exploit").AddItem(new MenuItem("LAGW", "Spam W(LAG)")).SetValue(new KeyBind("H".ToCharArray()[0], KeyBindType.Toggle));
			Config.SubMenu("Exploit").AddItem(new MenuItem("LAGE", "Spam E(LAG)")).SetValue(new KeyBind("J".ToCharArray()[0], KeyBindType.Toggle));
			Config.SubMenu("Exploit").AddItem(new MenuItem("LAGR", "Spam R(LAG)")).SetValue(new KeyBind("K".ToCharArray()[0], KeyBindType.Toggle));
				
            Config.AddToMainMenu(); 
            Game.OnGameUpdate += game_Update;

        }

        private static void game_Update(EventArgs args)
        {
            if (Config.Item("LAGQ").GetValue<KeyBind>().Active)
            {
                    foreach (Obj_AI_Base minion in ObjectManager.Get<Obj_AI_Base>().Where(minion => minion.IsEnemy))
                    {
                        if (minion.ServerPosition.Distance(ObjectManager.Player.ServerPosition) > 1000)
                        {
                                _Q.CastOnUnit(minion);
                        }
                    }
            }
			if (Config.Item("LAGW").GetValue<KeyBind>().Active)
            {
                    foreach (Obj_AI_Base minion in ObjectManager.Get<Obj_AI_Base>().Where(minion => minion.IsEnemy))
                    {
                        if (minion.ServerPosition.Distance(ObjectManager.Player.ServerPosition) > 1000)
                        {
                                _W.CastOnUnit(minion);
                        }
                    }
            }
			if (Config.Item("LAGE").GetValue<KeyBind>().Active)
            {
                    foreach (Obj_AI_Base minion in ObjectManager.Get<Obj_AI_Base>().Where(minion => minion.IsEnemy))
                    {
                        if (minion.ServerPosition.Distance(ObjectManager.Player.ServerPosition) > 1000)
                        {
                                _E.CastOnUnit(minion);
                        }
                    }
            }
			if (Config.Item("LAGR").GetValue<KeyBind>().Active)
            {
                    foreach (Obj_AI_Base minion in ObjectManager.Get<Obj_AI_Base>().Where(minion => minion.IsEnemy))
                    {
                        if (minion.ServerPosition.Distance(ObjectManager.Player.ServerPosition) > 1000)
                        {
                                _R.CastOnUnit(minion);
                        }
                    }
            }
        }

        }
}
