namespace Orc.Calendar.Tests
{
    using System.Runtime.CompilerServices;
    using ApiApprover;
    using NUnit.Framework;

    [TestFixture]
    public class PublicApiFacts
    {
        [Test, MethodImpl(MethodImplOptions.NoInlining)]
        public void Orc_Calendar_HasNoBreakingChanges()
        {
            var assembly = typeof(DateTimeExtensions).Assembly;

            PublicApiApprover.ApprovePublicApi(assembly);
        }
    }
}
