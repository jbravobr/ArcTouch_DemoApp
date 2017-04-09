using Xamarin.Forms;

namespace ArcTouch.TestApp
{
    public static class Styles
    {
        public static double BaseFontSize = 16;
        public static double BaseButtonHeight = 44;
        public static double BaseButtonBorderRadius = 44;

        public static Color DarkBackgroundColor = Color.Black;
        public static Color MainWrapperBackgroundColor = Color.FromHex("#EFEFEF");
        public static Color BasePageColor = Color.FromHex("#FFFFFF");
        public static Color BaseTextColor = Color.FromHex("#666666");
        public static Color AccentColor = Color.FromHex("#FFDA125F");
        public static Color LabelButtonColor = Color.FromHex("#ffffff");
        public static Color ComplementColor = Color.FromHex("#525ABB");

        public static string IconsFontFamily = "grialshapes";

        public static Style FontIconBase = new Style(typeof(Label))
        {
            Setters =
            {
                new Setter
                {
                    Property = Label.FontFamilyProperty,
                    Value = IconsFontFamily
                }
            }
        };

        static readonly Style RoundedButtonStyle = new Style(typeof(Button))
        {
            Setters =
            {
                new Setter
                {
                    Property = Button.FontSizeProperty,
                    Value = BaseFontSize
                },
                new Setter
                {
                    Property = Button.BorderRadiusProperty,
                    Value = BaseButtonBorderRadius
                },
                new Setter
                {
                    Property = VisualElement.HeightRequestProperty,
                    Value = BaseButtonHeight
                }
            }
        };

        public static Style PrimaryActionButtonStyle = new Style(typeof(Button))
        {
            Setters =
            {
                new Setter
                {
                    Property = VisualElement.BackgroundColorProperty,
                    Value = AccentColor
                },
                new Setter
                {
                    Property = Button.TextColorProperty,
                    Value = LabelButtonColor
                },
                new Setter
                {
                    Property = VisualElement.HeightRequestProperty,
                    Value = BaseButtonHeight
                }
            },
            BasedOn = RoundedButtonStyle
        };
    }
}