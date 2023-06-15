using Database.Entities;
using Services.Services;

namespace TestsServices
{
    public class PasswordTests
    {
        [Fact]
        public void CreatePasswordTest()
        {
            // Arrange
            var plainPassword = "myPassword";

            // Act
            var password = PasswordHelper.CreatePassword(plainPassword);

            // Assert
            Assert.NotNull(password);
            Assert.NotNull(password.Salt);
            Assert.NotNull(password.Hash);
            Assert.True(0 < password.Round);
        }

        [Fact]
        public void UpdatePasswordTest()
        {
            // Arrange
            var password = new Password
            {
                Salt = new byte[] { 1, 2, 3 },
                Hash = new byte[] { 4, 5, 6 },
                Round = 0
            };
            var plainPassword = "newPassword";

            // Act
            PasswordHelper.UpdatePassword(password, plainPassword);

            // Assert
            Assert.True(0 < password.Round);
            Assert.NotNull(password.Salt);
            Assert.NotNull(password.Hash);
        }
    }
}