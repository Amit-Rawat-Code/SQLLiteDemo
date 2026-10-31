using SQLLiteDemo.Forms;

namespace SQLLiteDemo.Common
{
    public static class ToastHelper
    {
        public static void ShowSuccess(Form parent, string message)
        {
            Show(parent, message, ToastType.Success);
        }

        public static void ShowError(Form parent, string message)
        {
            Show(parent, message, ToastType.Error);
        }
        public static void ShowWarning(Form parent, string message)
        {
            Show(parent, message, ToastType.Warning);
        }

        public static void ShowInfo(Form parent, string message)
        {
            Show(parent, message, ToastType.Info);
        }

        private static void Show(Form parent, string message, ToastType type)
        {
            ToastForm toast = new ToastForm(parent, message, type)
            {
                Owner = parent
            };
            toast.Show();
        }
    }
}
