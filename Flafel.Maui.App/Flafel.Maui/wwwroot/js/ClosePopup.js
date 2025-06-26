window.setupClosingPopUp = (selectBtn, popup, dotnetHelper) => {
    document.addEventListener('click', function (event) {

        // Check if popup is visible
        console.log(popup)
        const isPopupVisible = popup.style.display !== 'none' && popup.offsetHeight > 0;
        console.log(isPopupVisible)
        // Only invoke ClosePopup if the dropdown is visible and the click is outside both elements
        /*!selectBtn.contains(event.target) &&*/
        if (isPopupVisible && !popup.contains(event.target)) {
            dotnetHelper.invokeMethodAsync('ClosePopup');
            console.log("done")
        }
    });
}

window.setupClosingTablePopup = (table, dotnetHelper) => {
    document.addEventListener('click', function (event) {

        const popup = table.querySelector(`.show-popup`);
        // Check if popup is visible
        console.log(popup)
        if (popup) {
            const isPopupVisible = popup.style.display !== 'none' && popup.offsetHeight > 0;

            // Only invoke ClosePopup if the dropdown is visible and the click is outside both elements
            if (isPopupVisible && !popup.contains(event.target)) {
                dotnetHelper.invokeMethodAsync('ClosePopup');
                console.log("done")
            }
        }
    });
}
