function ChangeTheme() {
    // false = day  true = night
    console.log(document.getElementById('toogle').checked);
    var theme = document.getElementById('toogle').checked;

    if(theme == true) {
        document.getElementById('body').style.backgroundColor = "#43494F";

        document.getElementById('title').style.color = "#F5F5F5";
        $('#navbar').addClass('navbar-dark').removeClass('navbar-light');
        $('#navbar').addClass('bg-dark').removeClass('bg-light');

        document.getElementById('quien-agrega').style.color = "#F5F5F5";
        document.getElementById('ul-items').style.color = "#F5F5F5";
    }
    if(theme == false) {
        document.getElementById('body').style.backgroundColor = "#FFFFFF";

        document.getElementById('title').style.color = "#303030";
        $('#navbar').addClass('navbar-light').removeClass('navbar-dark');
        $('#navbar').addClass('bg-light').removeClass('bg-dark');

        document.getElementById('quien-agrega').style.color = "#303030";
        document.getElementById('ul-items').style.color = "#303030";
    }
}