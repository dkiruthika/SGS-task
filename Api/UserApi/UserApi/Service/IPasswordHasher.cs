namespace UserApi.Service
{
    public interface IPasswordHasher
    {
        string Hash(string password);
        /// <summary>
        /// Verify input password
        /// </summary>
        /// <param name="passwordHash"></param>
        /// <param name="inputPassword"></param>
        /// <returns></returns>
        bool VerifyPassword(string passwordHash, string inputPassword);
    }
}
