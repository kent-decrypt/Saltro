namespace Saltro.Domain.Entities;

public sealed partial class UserSubscription : BaseEntity
{
    /// <summary>
    /// Creates a new UserSubscription entity that will be ready for saving
    /// </summary>
    /// <param name="user"></param>
    /// <param name="subscription"></param>
    /// <param name="opslag"></param>
    /// <returns></returns>
    public static UserSubscription Create(int user, string? subscription, decimal? opslag = null)
    {
        var userSubscription = new UserSubscription()
        {
            UserId = user,
            Subscription = subscription,
            Opslag = opslag
        };

        return userSubscription;
    }

    /// <summary>
    /// Creates a new UserSubscription entity that will be ready for saving
    /// </summary>
    /// <param name="user"></param>
    /// <param name="subscription"></param>
    /// <param name="opslag"></param>
    /// <returns></returns>
    public static UserSubscription Create(User user, string? subscription, decimal? opslag = null)
    {
        var userSubscription = new UserSubscription()
        {
            User = user,
            Subscription = subscription,
            Opslag = opslag
        };

        return userSubscription;
    }

    /// <summary>
    /// Change the user's subscription
    /// </summary>
    /// <param name="subscription"></param>
    /// <returns></returns>
    public UserSubscription ChangeSubscription(string subscription)
    {
        Subscription = subscription;

        return this;
    }

    /// <summary>
    /// Change the opslag
    /// </summary>
    /// <param name="opslag"></param>
    /// <returns></returns>
    public UserSubscription ChangeOpslag(decimal? opslag)
    {
        Opslag = opslag;

        return this;
    }
}
