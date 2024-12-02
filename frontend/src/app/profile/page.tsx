import React from "react";
import ProfilePage from "./ProfilePage";
import Navbar from "../navbar/Navbar";


const Profile = () => {
  return (
    <main className="min-h-screen">
      <Navbar />
      <section className="p-20">
        <div className="flex flex-col justify-center"></div>
        <ProfilePage/>
        </section>
        </main>
  );
};

export default Profile;