namespace S_tp1
{
    public class Utilitaire
    {

        /*
         * Change la couleur du message dans la console pour les erreurs
         */
        public static void consoleState(bool isError)
        {
            Console.ForegroundColor = isError ? ConsoleColor.Red : ConsoleColor.White;
        }

    }
}