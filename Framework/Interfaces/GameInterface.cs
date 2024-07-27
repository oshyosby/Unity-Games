namespace Interfaces {
    using Framework;

    public interface GameInterface {
    
        string Name { get; set;}
        SDataModel SDataModel { get;}

        void Run() {}
        void Action() {}
        void Stop() {}

        void Menu() {}
        void Saves() {}
        void Settings() {}
    }
}