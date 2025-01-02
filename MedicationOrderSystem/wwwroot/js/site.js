document.addEventListener("DOMContentLoaded", function () {
  const button = document.getElementById("myButton");
  if (button) {
    button.addEventListener("click", function () {
      alert("Button clicked");
    });
  } else {
    console.log("Button not found");
  }
});

document.getElementById("orderForm").addEventListener("submit", async (e) => {
  e.preventDefault();

  const formData = {
    medicationName: document.getElementById("medicationName").value,
    medicationType: document.getElementById("medicationType").value,
    quantity: parseInt(document.getElementById("quantity").value),
    distributor: document.querySelector('input[name="distributor"]:checked')
      .value,
    pharmacyBranch: Array.from(
      document.querySelectorAll('input[name="pharmacyBranch"]:checked')
    )
      .map((cb) => cb.value)
      .join(", ")
  };

  try {
    const response = await fetch("/api/orders", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(formData)
    });

    if (response.ok) {
      alert("Order successfully placed!");
    } else {
      alert("Error placing the order.");
    }
  } catch (error) {
    console.error("Error:", error);
    alert("Failed to connect to the server.");
  }
});
