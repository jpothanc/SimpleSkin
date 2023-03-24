## SimpleSkin

SimpleSkin is a lightweight class library that allows you to quickly and easily add custom skins to your Windows Forms application. With SimpleSkin, you can give your application a fresh and unique look without needing to spend hours modifying the appearance of individual controls.

Requirements
.NET Framework 4.7.1 or higher
Windows Forms application

Getting Started
To use SimpleSkin, simply add the SimpleSkin.dll library to your project references.

To apply a skin to your Windows Forms application:

Create an instance of the SimpleSkin class and pass in the path to your application's .exe file.
csharp
Copy code
 private void MainForm_Load(object sender, EventArgs e)
{
    ApplySkin();
}
private void ApplySkin()
{
    var simpleSkin = SimpleSkin.SimpleSkin.Create(x =>
    {
        x.Skin = Skin.Dark;
        //Provide control name seperated by comma for exclusion
        x.ControlExcludes = "ComboBox";
    });

    simpleSkin.ApplyAll(this);
}

That's it! Your application should now have a new look and feel based on the selected skin.

Supported Skins
SimpleSkin currently supports the following skins:

Dark



Feedback and Support
If you encounter any issues while using SimpleSkin, or if you have any suggestions for new features or improvements, please open an issue on the GitHub repository.

Thank you for using SimpleSkin!

Regenerate response
