using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace Bismuth.Utilities.ModSupport
{
    public enum QuestPhase
    {
        PreSkeletron,
        PostOriginalAlchemist,
        PostOriginalBabaYaga,
        PostOriginalDwarfBlacksmith
    }
    public enum PostBossQuest
    {
        Null,
        PostEoC,
        PostBoss2,
        PostSkeletron,
        PostQueenBee,
        PostDeerclops,
        PostWoF,
        PostQueenSlime,
        PostMechBosses,
        PostTwins,
        PostDestroyer,
        PostSkeletronPrime,
        PostPlantera,
        PostGolem,
        PostDukeFishron,
        PostEmpress,
        PostCultist,
        PostMoonLord
    }
    public interface IQuest
    {
        string UniqueKey { get; }
        string NpcKey { get; }
        string DisplayName { get; }
        string DisplayDescription { get; }
        string DisplayStage { get; }
        int Progress { get; set; }
        int Priority { get; }
        int CornerItem { get; }
        bool ISManyEndings { get; }
        QuestPhase Phase { get; }
        bool HasDefeated(PostBossQuest postBossQuest);
        string GetChat(NPC npc, Player player);
        string GetButtonText(Player player);
        string GetButtonText(Player player, ref bool Isfristclicked);
        void OnChatButtonClicked(Player player);
        void IsActiveQuestUIIcon(bool isAvailableQuest, bool isActiveQuest, SpriteBatch spriteBatch, NPC npc, Player player);
        void Notification(Player player, bool isCompletedSuccessfully, bool isQuestAccepted);
        int ModifyNotificationText(Player player, string text, Color color);
        int CompletedQuickSpawnItem(Player player, int itemId, int quantity = 1);
        int RandomValue(int min, int max);
        void CheckItem(Player player, ref bool result, int itemId, int neededCount = 1, int consumeCount = 1, string successText = "", string failText = "", int rewardId = 0, int rewardStack = 0, bool showNotification = true, bool markCompleted = true, int progress = 0);
        bool IsAvailable(Player player);
        bool IsActive(Player player);
        bool IsCompleted(Player player) => false;
    }
}