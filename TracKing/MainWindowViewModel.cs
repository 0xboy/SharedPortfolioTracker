using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TracKing.Infrastructure;
using TracKing.Infrastructure.Aggregate;
using TracKing.Infrastructure.Command;
using TracKing.Infrastructure.Context;
using TracKing.Infrastructure.IoC;
using TracKing.Infrastructure.Query;
using IContainer = TracKing.Infrastructure.IoC.IContainer;

namespace TracKing
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        public string? dataAddResult = string.Empty;

        public ObservableCollection<User> users { get;private set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindowViewModel() 
        {
            this.users = new ObservableCollection<User>();


            UserContext userContext = new UserContext();

            IContainer container = new SimpleContainer();

            BootStrapper.Configure(container);

            ICommandDispatcher commandDispatcher = container.Resolve<ICommandDispatcher>();
            IQueryDispatcher queryDispatcher = container.Resolve<IQueryDispatcher>();

            dataAddResult = "Dummy data adding to the db...";

            var createCommand = new CreateUserCommand { UserName = "Berkay", Balance = 0m, Name = "Ahmet Can", Password = "///", Share = 0.0 };
            commandDispatcher.Execute(createCommand);

            dataAddResult += "\nDummy data added to the db...";

            dataAddResult += "\nDummy data retriving from the db...";

            var getUsersQuery = new GetUsersQuery();

            getUsersQuery.Predicate = (t) => t.UserName == "Berkay";

            IQueryable<User> users = queryDispatcher.Query<GetUsersQuery, IQueryable<User>>(getUsersQuery);            

            foreach (User user in users.ToList()) 
            {
                this.users.Add(user);
            }            

            dataAddResult += "\nDummy data retrivied from the db...";
        }
    }
}
