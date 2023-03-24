## SimpleSkin

SimpleSkin is a lightweight class library that allows you to quickly and easily add custom skins to your Windows Forms application. With SimpleSkin, you can give your application a fresh and unique look without needing to spend hours modifying the appearance of individual controls.

Requirements
.NET Framework 4.7.1 or higher
Windows Forms application

`<u>Getting Started</u>`

To use SimpleSkin, simply install SimpleSkin from NuGet
<https://www.nuget.org/packages/SimpleSkin/3.1.0>

To apply a skin to your Windows Forms application:

Create an instance of the SimpleSkin as below

```cs
private void MainForm_Load(object sender, EventArgs e)
{
    ApplySkin();
}
private void ApplySkin()
{
    var simpleSkin = SimpleSkin.SimpleSkin.Create(x =>
    {
        x.Skin = Skin.Dark;
        //Provide control names seperated by comma for exclusion
        x.ControlExcludes = "ComboBox";
    });

    simpleSkin.ApplyAll(this);
}
```

That's it! Your application should now have a new look and feel based on the selected skin.

Supported Skins
SimpleSkin currently supports the following skins:

Dark



Feedback and Support
If you encounter any issues while using SimpleSkin, or if you have any suggestions for new features or improvements, please open an issue on the GitHub repository.

Thank you for using SimpleSkin!

Regenerate response
