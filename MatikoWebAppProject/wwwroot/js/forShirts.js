function ChangedSomething() {
    sortval = document.getElementsById('sortby');
    genderval = document.getElementsById('genderby');
    colorval = document.getElementsById('colorby');
    window.location.href = (Url.Action("Shirts", "Products", new {sort = sortval, gender = genderval, color = colorval}));
}

function GoToItem(itemid) {
    window.location.href = 'Details/' + itemid;
}