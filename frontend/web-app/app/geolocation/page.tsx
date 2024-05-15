"use client"

import React, { useState } from "react";
import PostForm from "./PostForm";

export default function Geolocation() {
  const [userLocation, setUserLocation] = useState<{
    latitude: number;
    longitude: number;
  } | null>(null);

  const getUserLocation = () => {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(
        (position) => {
          const { latitude, longitude } = position.coords;

          setUserLocation({ latitude, longitude });
        },

        (error) => {
          console.error("Error getting user location: ", error);
        }
      );
    } else {
      console.log("Geolocation is not supported by this browser");
    } 
  };

  return (
    <>
      <h1>Geolocation App</h1>
      {/* create a button that is mapped to the function which retrieves the users location */}
      <button onClick={getUserLocation}>Get User Location</button>
      {/* if the user location variable has a value, print the users location */}
      {userLocation && (
        <div>
          <h2>User Location</h2>
          <p>Latitude: {userLocation.latitude}</p>
          <p>Longitude: {userLocation.longitude}</p>
        </div>
      )}
    <PostForm onClick={getUserLocation} userLocation={userLocation} />
    </>
  );
}