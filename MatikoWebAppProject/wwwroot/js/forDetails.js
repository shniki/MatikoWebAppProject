
function AddToWishList(id) {
    string sizeval = document.getElementsById('selectSize').value;
    if (sizeval == "")
        alert("You must choose a size");
    else {
        window.location.href = Url.Action("Cart", "Orders", new { products = id, size = sizeval, isAddition = 1 });
    }
}