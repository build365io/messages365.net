import NextAuth, { NextAuthOptions } from "next-auth"
import DuendeIdentityServer6 from 'next-auth/providers/duende-identity-server6';
import { authOptions } from "./auth";

const handler = NextAuth(authOptions);
export { handler as GET, handler as POST }