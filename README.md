# Custom Guitar Manufacturing Program

## Overview
This program simulates the operations of a guitar manufacturing facility. It allows the user to interact with a series of manufacturing facilities, manage inventory, place custom guitar orders, and display order details. The program includes features for altering inventory, toggling factory operation status, and handling guitar orders with custom specifications.

## Features

### 1. **Inventory Management**
   - Users can change the inventory levels for body frames, strings, and pickups in each facility.
   - Inventory is automatically updated when guitars are ordered.

### 2. **Custom Guitar Orders**
   - Users can place custom guitar orders by specifying the body shape, string count, pickup count, and whether they want a whammy bar.
   - Each custom guitar is priced based on the selected features.

### 3. **Factory Operations**
   - The user can toggle the operational status of any facility (start or stop factory operations).
   - Facilities may have different levels of inventory and may be in operation or not.

### 4. **Facility Management**
   - Users can view detailed information about the facilities, including their current inventory and operational status.
   - New facilities can be opened, and their inventory is initialized to default values.

## Classes

### 1. **Manufacturing**
   - Represents a manufacturing facility with properties for body frame inventory, string inventory, pickup inventory, and operational status.
   - Includes methods for changing inventory, displaying facility information, toggling operation status, and opening new facilities.

### 2. **CustomGuitar**
   - Represents a custom guitar with properties for body shape, string count, pickup count, whammy bar, and price.
   - Includes methods for placing orders, calculating prices, and displaying order details.

## Main Program Flow

1. **Main Menu**: The user is prompted with a menu of options:
   - Change inventory
   - Place custom orders
   - Toggle factory operation status
   - Display orders
   - Display facility information
   - Open a new facility

2. **Custom Guitar Order**: When placing a custom order, the user selects from various body shapes, string counts, and pickup counts. The program ensures sufficient inventory is available before allowing the order.

3. **Order Display**: After placing orders, users can view a summary of all custom guitars ordered, with details such as body shape, string count, pickup count, whammy bar presence, and price.

## Example Usage

```csharp
// Main program initializes three manufacturing facilities
Manufacturing facility1 = new Manufacturing(1, 20, 150, 50, false);
Manufacturing facility2 = new Manufacturing(2, 30, 200, 70, false);
Manufacturing facility3 = new Manufacturing(3, 25, 180, 60, false);

// Adding facilities to the list
Manufacturing.factory.Add(facility1);
Manufacturing.factory.Add(facility2);
Manufacturing.factory.Add(facility3);
