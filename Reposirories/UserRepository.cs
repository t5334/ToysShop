using System.Text.Json;
using Entities;
namespace Reposirories
{
    public class UserRepository : IUserRepository
    {
        public string filePath = "M:\\web-api\\user.txt";
        public User register(User user)
        {
            if (!System.IO.File.Exists(filePath))
            {
                System.IO.File.Create(filePath).Close();
            }
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.userId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
            return user;
        }
        public User login(User user)
        {
            using (StreamReader reader = System.IO.File.OpenText("M:\\web-api\\user.txt"))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user1 = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.userName == user1.userName && user.password == user1.password)
                        return user1;
                }
                return null;
            }
        }
        public User updateUser(int id, User userToUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText("M:\\web-api\\user.txt"))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.userId == id)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText(filePath, text);
                return userToUpdate;
            }
            return null;
        }

    }
}
