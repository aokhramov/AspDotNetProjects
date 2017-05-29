namespace PetShop.Helpers
{
    using System.Web.SessionState;
    using Models;
    public static class SessionHelper
    {
        public static Purchase GetPurchase (HttpSessionState session)
        {
            object dataValue = session["Purchase"];
            Purchase purchase = (dataValue != null && dataValue is Purchase) ? (Purchase)dataValue : new Purchase();
            session["Purchase"] = purchase;
            return purchase;
        }
    }
}