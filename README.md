# 🚗 Vehicle Rental Management System (SwiftRent)

This project is designed to easily manage the daily operations (Rentals, Vehicles, Customers) of a vehicle rental business. It includes a central Dashboard and core functional modules.

---

## 📢 Important Note for the Team

> **Latest Update:** I have completely finished designing the main **System Overview Dashboard** and the **Login Form** UI.
> 
> ⚠️ **If Panels or UI Elements are Not Displaying:**
> When you pull the project, you might notice that some panels, buttons, or rounded corners (curves) on the Dashboard are not visible. This happens because the **Guna.UI2** package might not automatically sync with your Visual Studio.
> 
> If you face this issue, please follow the steps below to download or restore the **Guna.UI2** NuGet Package.

---

## 🛠️ How to Fix Guna UI Package Issue

If the UI looks broken, generic, or completely blank on your computer, please follow these steps:

1. In Visual Studio, go to the top menu and select **Tools** ➔ **NuGet Package Manager** ➔ **Manage NuGet Packages for Solution...**
2. Check the **Installed** tab. (If it's not there, go to the **Browse** tab and search for `Guna.UI2`).
3. Select **Guna.UI2**, check the box next to your project name on the right panel, and click the **Install** or **Update/Restore** button.
4. Once installed, go to **Build** ➔ **Clean Solution**, and then click **Rebuild Solution**. Everything should work perfectly!

---

## 🚀 Completed Features

* **Responsive Login UI:** A beautifully styled SwiftRent Login Form that automatically centers itself perfectly on any screen size.
* **Real-time Stat Counters (Card System):** Live data cards directly linked to the database, displaying:
  * **Total Fleet Size:** Total number of registered vehicles.
  * **Active Rentals:** Vehicles currently out on rent.
  * **Pending Returns:** Vehicles expected to be returned today.
  * **Vehicles in Maintenance:** Vehicles currently under repair/service.
* **Recent Transactions Grid:** A highly secure, full-screen stretching Dark Blue DataGridView that automatically loads the last 5 transactions.
* **Local SQLite Database Setup:** Configured using Relative Paths (`|DataDirectory|`) so that the database works instantly on anyone's computer without path errors.

---

## 🗄️ Database Information

* **Database Engine:** SQLite 3
* **File Name:** `vehicle_rental.db` (Located inside the `\Database\` folder)
* **Connection String:** `Data Source=|DataDirectory|\Database\vehicle_rental.db;Version=3;`

---

## 👥 To-Do for Team Members (Next Steps)

- [ ] Connect the Vehicle Management Form to the main Dashboard.
- [ ] Create and design the Customer Registration Form.
- [ ] Develop modules required for printing reports and invoices.

---
💡 *If you run into any issues, just drop a message in our group chat!*
