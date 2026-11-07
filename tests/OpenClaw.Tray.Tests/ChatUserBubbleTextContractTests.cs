namespace OpenClaw.Tray.Tests;

public sealed class ChatUserBubbleTextContractTests
{
    [Fact]
    public void UserPromptText_RendersSelectableRichTextBlockParagraph()
    {
        var timeline = Read("src", "OpenClaw.Tray.WinUI", "Chat", "ReactorChatTimeline.cs");

        Assert.Contains("private static Element BuildUser(", timeline);
        Assert.Contains("content.Add(Text(", timeline);
        Assert.Contains("messageText,", timeline);
        Assert.Contains(".IsTextSelectionEnabled(true)", timeline);
        Assert.Contains("var accessibleText = BuildAccessibleUserText(messageText, attachments)", timeline);
        Assert.Contains("\"{LocalizedOrDefault(\"Chat_Timeline_UserSenderLabel\", \"You\")}: {UserAccessibleText(row, entry)}\"", timeline);
        Assert.Contains(".AutomationName(name)", timeline);
    }

    private static string Read(params string[] parts)
        => File.ReadAllText(Path.Combine(new[] { TestRepositoryPaths.GetRepositoryRoot() }.Concat(parts).ToArray()));
}
