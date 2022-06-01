using Office_1.DataLayer.Models;

namespace Office_1.DataLayer.Services
{
    public static class RequestService
    {

        public static IEnumerable<Request> GetSpecialRequests(bool showCreated, bool showInReview, bool showReviewed,
            bool showDeclined)
        {
            using var context = new ApplicationContext();

            var query = context.Requests.AsQueryable();

            if (showCreated)
            {
                query = query.Where(r => r.Status == Status.Created);
            }

            if (showInReview)
            {
                query = query.Where(r => r.Status == Status.InReview);
            }

            if (showReviewed)
            {
                query = query.Where(r => r.Status == Status.Reviewed);
            }

            if (showDeclined)
            {
                query = query.Where(r => r.Status == Status.Declined);
            }

            return query;
        }

        public static IEnumerable<Request> GetAllRequests()
        {
            using var context = new ApplicationContext();

            return context.Requests;
        }

        public static void UpdateRequest(Request request)
        {
            using var context = new ApplicationContext();

            context.Requests.Update(request);
        }

        public static void InsertRequest(Request request)
        {
            using var context = new ApplicationContext();

            context.Requests.Add(request);
        }

    }
}