using Terraria.Localization;

namespace Bismuth.Utilities {
    public class LocUtil {
        public static string Loc(string key) => Language.GetTextValue("Mods.Bismuth." + key);
    }
}
