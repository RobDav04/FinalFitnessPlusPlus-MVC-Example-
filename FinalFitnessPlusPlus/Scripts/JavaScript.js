window.onload = fadeIn;
function fadeIn() {
    document.getElementById("myHeading").style.opacity = 1;
}
function calculate1RM() {
    // Get input values
    let totalWeight = parseFloat(document.getElementById('weight-KG').value);
    let totalReps = parseInt(document.getElementById('reps-completed').value);
    let calculated1RM = 0;

    // Check if the inputs are valid
    if (isNaN(totalWeight) || isNaN(totalReps) || totalReps <= 0) {
        document.getElementById('change-1Rm').innerText = "Please enter valid weight and repetitions.";
        document.getElementById('percentage-results-container').style.display = 'none'; // Hide percentage results
        return;
    }

    // Using the Brzycki formula to calculate 1RM
    calculated1RM = totalWeight / (1.0278 - 0.0278 * totalReps);

    // Calculate percentages
    let percentage90 = calculated1RM * 0.9;
    let percentage80 = calculated1RM * 0.8;
    let percentage70 = calculated1RM * 0.7;
    let percentage60 = calculated1RM * 0.6;
    let percentage50 = calculated1RM * 0.5;


    // Display the results
    document.getElementById('change-1Rm').innerText = "Your estimated 1RM is: " + calculated1RM.toFixed(0) + " KG";

    // Display percentage results
    document.getElementById('change-90').innerText = "90% of your 1RM: " + percentage90.toFixed(0) + " KG";
    document.getElementById('change-80').innerText = "80% of your 1RM: " + percentage80.toFixed(0) + " KG";
    document.getElementById('change-70').innerText = "70% of your 1RM: " + percentage70.toFixed(0) + " KG";
    document.getElementById('change-60').innerText = "60% of your 1RM: " + percentage60.toFixed(0) + " KG";
    document.getElementById('change-50').innerText = "50% of your 1RM: " + percentage50.toFixed(0) + " KG";

    // Show percentage results
    document.getElementById('percentage-results-container').style.display = 'block'; // Show the percentage results row
}


