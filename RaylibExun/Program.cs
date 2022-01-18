using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.CameraProjection;
using static Raylib_cs.Color;

namespace Examples
{
    public class core_3d_camera_first_person
    {
        public const int NUM_FRAMES = 3;
        static float cubex = 0.1f;
        static float cubey = 1.5f;
        static float cubez = 0.5f;

        static float winx = 0.3f;
        static float winy = 0.0f;
        static float winz = 2f;

        static float decorx = 0.1f;
        static float decory = 7f;
        static float decorz = 0.5f;

        static float decorSphereSize = 0.35f;

        static float enemyX = 0.15f;
        static float enemyY = 2.5f;
        static float enemyZ = 0.15f;

        static float enemyUp1X = 0.19f;
        static float enemyUp1Y = 0.1f;
        static float enemyUp1Z = 0.65f;

        static float enemy1X = 0.15f;
        static float enemy1Y = 0.75f;
        static float enemy1Z = 0.15f;

        static float enemyUp2X = 0.15f;
        static float enemyUp2Y = 0.1f;
        static float enemyUp2Z = 1.6f;

        static float enemy2X = 0.15f;
        static float enemy2Y = 2.5f;
        static float enemy2Z = 0.15f;

        static float enemyUp3X = 0.19f;
        static float enemyUp3Y = 0.1f;
        static float enemyUp3Z = 0.65f;

        static float SphereSize1 = 0.1f;
        static float SphereSize2 = 0.1f;
        static float SphereSize3 = 0.1f;

        static float SphereSize4 = 0.1f;
        static float SphereSize5 = 0.1f;
        static float SphereSize6 = 0.1f;
        static float SphereSize7 = 0.1f;
        static float SphereSize8 = 0.1f;
        static float SphereSize9 = 0.1f;
        static float SphereSize10 = 0.1f;
        static float SphereSize11 = 0.1f;
        static float SphereSize12 = 0.1f;

        static float score = 0;
        static float unmute_size = 0.17f;
        static float mute_size = 0;

        static bool pauseMusic = false;

        static bool collision = false;
        static bool scoreCollision1 = false;
        static bool scoreCollision2 = false;
        static bool scoreCollision3 = false;
        static bool scoreCollision4 = false;
        static bool scoreCollision5 = false;
        static bool scoreCollision6 = false;
        static bool scoreCollision7 = false;
        static bool scoreCollision8 = false;
        static bool scoreCollision9 = false;
        static bool scoreCollision10 = false;
        static bool scoreCollision11 = false;
        static bool scoreCollision12 = false;

        static bool wincollision = false;

        public enum GameScreen { LOGO = 0, RETRY, GAMEPLAY, PAUSE }
        public static int Main()
        {
            const int screenWidth = 1200;
            const int screenHeight = 800;
            InitAudioDevice();

            GameScreen currentScreen = GameScreen.LOGO;

            Color playerColor = GREEN;

            InitWindow(screenWidth, screenHeight, "Jelly Shift remake");

            Vector3 cubePosition = new Vector3(3.0f, 0.0f, 0.0f);
            Vector3 winbox = new Vector3(55.0f, 0.2f, 0.15f);
            Vector3 decorpos = new Vector3(0.0f, -2f, -2.0f);
            Vector3 decorSpherePos = new Vector3(0.0f, 2.0f, -2.0f);

            Vector3 enemyBoxPos = new Vector3(15.0f, 0.0f, -0.25f);
            Vector3 enemyBoxPos1 = new Vector3(15.0f, 0.0f, +0.25f);
            Vector3 enemyBoxPosUp1 = new Vector3(15.0f, 1.25f, 0.0f);

            Vector3 enemyBoxPos2 = new Vector3(28.0f, 0.0f, -0.75f);
            Vector3 enemyBoxPos3 = new Vector3(28.0f, 0.0f, +0.75f);
            Vector3 enemyBoxPosUp2 = new Vector3(28.0f, 0.35f, 0.0f);

            Vector3 enemyBoxPos4 = new Vector3(42.0f, 0.0f, -0.25f);
            Vector3 enemyBoxPos5 = new Vector3(42.0f, 0.0f, +0.25f);
            Vector3 enemyBoxPosUp3 = new Vector3(42.0f, 1.25f, 0.0f);

            Vector3 SpherePos1 = new Vector3(5.0f, 0.3f, 0.0f);
            Vector3 SpherePos2 = new Vector3(8.0f, 0.3f, 0.0f);
            Vector3 SpherePos3 = new Vector3(11.0f, 0.3f, 0.0f);
            Vector3 SpherePos4 = new Vector3(18.0f, 0.3f, 0.0f);
            Vector3 SpherePos5 = new Vector3(21.0f, 0.3f, 0.0f);
            Vector3 SpherePos6 = new Vector3(24.0f, 0.3f, 0.0f);
            Vector3 SpherePos7 = new Vector3(31.0f, 0.3f, 0.0f);
            Vector3 SpherePos8 = new Vector3(34.0f, 0.3f, 0.0f);
            Vector3 SpherePos9 = new Vector3(37.0f, 0.3f, 0.0f);
            Vector3 SpherePos10 = new Vector3(45.0f, 0.3f, 0.0f);
            Vector3 SpherePos11 = new Vector3(48.0f, 0.3f, 0.0f);
            Vector3 SpherePos12 = new Vector3(51.0f, 0.3f, 0.0f);

            Camera3D camera = new Camera3D();
            camera.up = new Vector3(0.0f, 1.0f, 0.0f);
            camera.fovy = 40.0f;
            camera.projection = CAMERA_PERSPECTIVE;

            Texture2D home = LoadTexture("C:/Users/nishi/source/repos/RaylibExun/RaylibExun/resources/home_button.png");
            Texture2D play = LoadTexture("C:/Users/nishi/source/repos/RaylibExun/RaylibExun/resources/play_button.png");
            Texture2D pause = LoadTexture("C:/Users/nishi/source/repos/RaylibExun/RaylibExun/resources/pause_button.png");
            Texture2D retry = LoadTexture("C:/Users/nishi/source/repos/RaylibExun/RaylibExun/resources/retry_button.png");
            Texture2D unmute = LoadTexture("C:/Users/nishi/source/repos/RaylibExun/RaylibExun/resources/unmute_button.png");
            Texture2D mute = LoadTexture("C:/Users/nishi/source/repos/RaylibExun/RaylibExun/resources/mute_button.png");
            Music music = LoadMusicStream("C:/Users/nishi/source/repos/RaylibExun/RaylibExun/resources/stay.mp3");
            PlayMusicStream(music);

            SetTargetFPS(60);
            

            while (!WindowShouldClose())
            {
                UpdateCamera(ref camera);
                UpdateMusicStream(music);

                switch (currentScreen) 
                {
                    case GameScreen.LOGO:

                        Vector2 mousePoint = new Vector2(0.0f, 0.0f);
                        mousePoint = GetMousePosition();

                        if (mousePoint.X >= 535 && mousePoint.X <= 670 && mousePoint.Y >= 450 && mousePoint.Y <= 600 && IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
                        {
                            currentScreen = GameScreen.GAMEPLAY;
                        }
                        if (mousePoint.X >= 460 && mousePoint.X <= 745 && mousePoint.Y >= 605 && mousePoint.Y <= 635 && IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
                        {
                            CloseWindow();
                        }

                        break;

                    case GameScreen.GAMEPLAY:

                        Vector2 mousePoint2 = new Vector2(0.0f, 0.0f);
                        mousePoint2 = GetMousePosition();

                        if (mousePoint2.X >= 100 && mousePoint2.X <= 170 && mousePoint2.Y >= 50 && mousePoint2.Y <= 130 && IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
                        {
                            currentScreen = GameScreen.LOGO;
                        }
                        if (mousePoint2.X >= 1015 && mousePoint2.X <= 1070 && mousePoint2.Y >= 65 && mousePoint2.Y <= 125 && IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
                        {
                            currentScreen = GameScreen.RETRY;
                        }
                        if (IsKeyPressed(KeyboardKey.KEY_R))
                        {
                            currentScreen = GameScreen.RETRY;
                        }
                        if (mousePoint2.X >= 235 && mousePoint2.X <= 275 && mousePoint2.Y >= 65 && mousePoint2.Y <= 120 && IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
                        {
                            currentScreen = GameScreen.PAUSE;
                        }
                        if (mousePoint2.X >= 880 && mousePoint2.X <= 965 && mousePoint2.Y >= 65 && mousePoint2.Y <= 130 && IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
                        {
                            pauseMusic = !pauseMusic;

                            if (pauseMusic)
                            {
                                PauseMusicStream(music);
                                unmute_size = 0;
                                mute_size = 0.17f;
                            }
                            else
                            {
                                ResumeMusicStream(music);
                                mute_size = 0;
                                unmute_size = 0.17f;
                            }
                        }

                        break;

                    case GameScreen.RETRY:
                        currentScreen = GameScreen.GAMEPLAY;
                        break;

                    case GameScreen.PAUSE:
                        Vector2 mousePoint3 = new Vector2(0.0f, 0.0f);
                        mousePoint3 = GetMousePosition();

                        if (IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON) || IsKeyPressed(KeyboardKey.KEY_P))
                        {
                            currentScreen = GameScreen.GAMEPLAY;
                        }
                        if (mousePoint3.X >= 520 && mousePoint3.X <= 700 && mousePoint3.Y >= 400 && mousePoint3.Y <= 430 && IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
                        {
                            currentScreen = GameScreen.GAMEPLAY;
                        }
                        if (mousePoint3.X >= 555 && mousePoint3.X <= 650 && mousePoint3.Y >= 500 && mousePoint3.Y <= 530 && IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
                        {
                            CloseWindow();
                        }
                        break;

                    default: break;
                }



                BeginDrawing();
                ClearBackground(new Color(255, 255, 196, 255));

                switch (currentScreen) 
                {
                    case GameScreen.LOGO:
                        ClearBackground(WHITE);
                        
                        DrawText("PRESS TO START PLAYING", 450, 300, 20, GRAY);
                        DrawText("JELLY SHIFT RAYLIB", 200, 200, 75, BLACK);
                        DrawText("QUIT GAME", 460, 600, 50, BLACK);

                        DrawTextureEx(play, new Vector2(525, 400), 0, 0.3f, DARKGRAY);
                        cubePosition = new Vector3(3.0f, 0.0f, 0.0f);
                        SphereSize1 = 0.1f;
                        SphereSize2 = 0.1f;
                        SphereSize3 = 0.1f;
                        SphereSize4 = 0.1f;
                        SphereSize5 = 0.1f;
                        SphereSize6 = 0.1f;
                        SphereSize7 = 0.1f;
                        SphereSize8 = 0.1f;
                        SphereSize9 = 0.1f;
                        SphereSize10 = 0.1f;
                        SphereSize11 = 0.1f;
                        SphereSize12 = 0.1f;
                        score = 0;

                        collision = false;
                        wincollision = false;
                        scoreCollision1 = false;
                        scoreCollision2 = false;
                        scoreCollision3 = false;
                        scoreCollision4 = false;
                        scoreCollision5 = false;
                        scoreCollision6 = false;
                        scoreCollision7 = false;
                        scoreCollision8 = false;
                        scoreCollision9 = false;
                        scoreCollision10 = false;
                        scoreCollision11 = false;
                        scoreCollision12 = false;
                        break;

                    case GameScreen.PAUSE:
                        ClearBackground(BLACK);
                        DrawText("PAUSED", 460, 250, 75, WHITE);
                        DrawText("RESUME", 520, 400, 45, LIGHTGRAY);
                        DrawText("QUIT", 555, 500, 45, LIGHTGRAY);

                        break;

                    case GameScreen.RETRY:
                        cubePosition = new Vector3(3.0f, 0.0f, 0.0f);
                        SphereSize1 = 0.1f;
                        SphereSize2 = 0.1f;
                        SphereSize3 = 0.1f;
                        SphereSize4 = 0.1f;
                        SphereSize5 = 0.1f;
                        SphereSize6 = 0.1f;
                        SphereSize7 = 0.1f;
                        SphereSize8 = 0.1f;
                        SphereSize9 = 0.1f;
                        SphereSize10 = 0.1f;
                        SphereSize11 = 0.1f;
                        SphereSize12 = 0.1f;

                        collision = false;
                        wincollision = false;
                        score = 0;
                        break;

                    case GameScreen.GAMEPLAY:
                        DrawTextureEx(home, new Vector2(100, 60), 0, 0.14f, DARKGRAY);
                        DrawTextureEx(pause, new Vector2(220, 60), 0, 0.14f, DARKGRAY);
                        DrawTextureEx(unmute, new Vector2(880, 55), 0, unmute_size, DARKGRAY);
                        DrawTextureEx(mute, new Vector2(880, 55), 0, mute_size, DARKGRAY);
                        DrawTextureEx(retry, new Vector2(1000, 55), 0, 0.17f, DARKGRAY);

                        BeginMode3D(camera);
                        camera.position = new Vector3(cubePosition.X - 5f, cubePosition.Y + 2f, cubePosition.Z + 2f);
                        camera.target = new Vector3(cubePosition.X + 2, 1.0f, 0.0f);

                        BoundingBox bb1 = new BoundingBox(new Vector3(cubePosition.X - (cubex / 2), cubePosition.Y - (cubey / 2), cubePosition.Z - (cubez / 2)), new Vector3(cubePosition.X + (cubex / 2), cubePosition.Y + (cubey / 2), cubePosition.Z + (cubez / 2)));

                        BoundingBox bb2 = new BoundingBox(new Vector3(enemyBoxPos.X - (enemyX / 2), enemyBoxPos.Y - (enemyY / 2), enemyBoxPos.Z - (enemyZ / 2)), new Vector3(enemyBoxPos.X + (enemyX / 2), enemyBoxPos.Y + (enemyY / 2), enemyBoxPos.Z + (enemyZ / 2)));
                        BoundingBox bb3 = new BoundingBox(new Vector3(enemyBoxPos1.X - (enemyX / 2), enemyBoxPos1.Y - (enemyY / 2), enemyBoxPos1.Z - (enemyZ / 2)), new Vector3(enemyBoxPos1.X + (enemyX / 2), enemyBoxPos1.Y + (enemyY / 2), enemyBoxPos1.Z + (enemyZ / 2)));

                        BoundingBox bb4 = new BoundingBox(new Vector3(enemyBoxPosUp2.X - (enemyUp2X / 2), enemyBoxPosUp2.Y - (enemyUp2Y / 2), enemyBoxPosUp2.Z - (enemyUp2Z / 2)), new Vector3(enemyBoxPosUp2.X + (enemyUp2X / 2), enemyBoxPosUp2.Y + (enemyUp2Y / 2), enemyBoxPosUp2.Z + (enemyUp2Z / 2)));

                        BoundingBox bb5 = new BoundingBox(new Vector3(SpherePos1.X - (SphereSize1 / 2), SpherePos1.Y - (SphereSize1 / 2), SpherePos1.Z - (SphereSize1 / 2)), new Vector3(SpherePos1.X + (SphereSize1 / 2), SpherePos1.Y + (SphereSize1 / 2), SpherePos1.Z + (SphereSize1 / 2)));
                        BoundingBox bb6 = new BoundingBox(new Vector3(SpherePos2.X - (SphereSize2 / 2), SpherePos2.Y - (SphereSize2 / 2), SpherePos2.Z - (SphereSize2 / 2)), new Vector3(SpherePos2.X + (SphereSize2 / 2), SpherePos2.Y + (SphereSize2 / 2), SpherePos2.Z + (SphereSize2 / 2)));
                        BoundingBox bb7 = new BoundingBox(new Vector3(SpherePos3.X - (SphereSize3 / 2), SpherePos3.Y - (SphereSize3 / 2), SpherePos3.Z - (SphereSize3 / 2)), new Vector3(SpherePos3.X + (SphereSize3 / 2), SpherePos3.Y + (SphereSize3 / 2), SpherePos3.Z + (SphereSize3 / 2)));
                        BoundingBox bb8 = new BoundingBox(new Vector3(SpherePos4.X - (SphereSize4 / 2), SpherePos4.Y - (SphereSize4 / 2), SpherePos4.Z - (SphereSize4 / 2)), new Vector3(SpherePos4.X + (SphereSize4 / 2), SpherePos4.Y + (SphereSize4 / 2), SpherePos4.Z + (SphereSize4 / 2)));
                        BoundingBox bb9 = new BoundingBox(new Vector3(SpherePos5.X - (SphereSize5 / 2), SpherePos5.Y - (SphereSize5 / 2), SpherePos5.Z - (SphereSize5 / 2)), new Vector3(SpherePos5.X + (SphereSize5 / 2), SpherePos5.Y + (SphereSize5 / 2), SpherePos5.Z + (SphereSize5 / 2)));
                        BoundingBox bb10 = new BoundingBox(new Vector3(SpherePos6.X - (SphereSize6 / 2), SpherePos6.Y - (SphereSize6 / 2), SpherePos6.Z - (SphereSize6 / 2)), new Vector3(SpherePos6.X + (SphereSize6 / 2), SpherePos6.Y + (SphereSize6 / 2), SpherePos6.Z + (SphereSize6 / 2)));
                        BoundingBox bb11 = new BoundingBox(new Vector3(SpherePos7.X - (SphereSize7 / 2), SpherePos7.Y - (SphereSize7 / 2), SpherePos7.Z - (SphereSize7 / 2)), new Vector3(SpherePos7.X + (SphereSize7 / 2), SpherePos7.Y + (SphereSize7 / 2), SpherePos7.Z + (SphereSize7 / 2)));
                        BoundingBox bb12 = new BoundingBox(new Vector3(SpherePos8.X - (SphereSize8 / 2), SpherePos8.Y - (SphereSize8 / 2), SpherePos8.Z - (SphereSize8 / 2)), new Vector3(SpherePos8.X + (SphereSize8 / 2), SpherePos8.Y + (SphereSize8 / 2), SpherePos8.Z + (SphereSize8 / 2)));
                        BoundingBox bb13 = new BoundingBox(new Vector3(SpherePos9.X - (SphereSize9 / 2), SpherePos9.Y - (SphereSize9 / 2), SpherePos9.Z - (SphereSize9 / 2)), new Vector3(SpherePos9.X + (SphereSize9 / 2), SpherePos9.Y + (SphereSize9 / 2), SpherePos9.Z + (SphereSize9 / 2)));
                        BoundingBox bb14 = new BoundingBox(new Vector3(SpherePos10.X - (SphereSize7 / 2), SpherePos10.Y - (SphereSize10 / 2), SpherePos10.Z - (SphereSize10 / 2)), new Vector3(SpherePos10.X + (SphereSize10 / 2), SpherePos10.Y + (SphereSize10 / 2), SpherePos10.Z + (SphereSize10 / 2)));
                        BoundingBox bb15 = new BoundingBox(new Vector3(SpherePos11.X - (SphereSize8 / 2), SpherePos11.Y - (SphereSize11 / 2), SpherePos11.Z - (SphereSize11 / 2)), new Vector3(SpherePos11.X + (SphereSize11 / 2), SpherePos11.Y + (SphereSize11 / 2), SpherePos11.Z + (SphereSize11 / 2)));
                        BoundingBox bb16 = new BoundingBox(new Vector3(SpherePos12.X - (SphereSize9 / 2), SpherePos12.Y - (SphereSize12 / 2), SpherePos12.Z - (SphereSize12 / 2)), new Vector3(SpherePos12.X + (SphereSize12 / 2), SpherePos12.Y + (SphereSize12 / 2), SpherePos12.Z + (SphereSize12 / 2)));


                        BoundingBox bb17 = new BoundingBox(new Vector3(winbox.X - (winx / 2), winbox.Y - (winy / 2), winbox.Z - (winz / 2)), new Vector3(winbox.X + (winx / 2), winbox.Y + (winy / 2), winbox.Z + (winz / 2)));

                        BoundingBox bb18 = new BoundingBox(new Vector3(enemyBoxPos4.X - (enemy2X / 2), enemyBoxPos4.Y - (enemy2Y / 2), enemyBoxPos4.Z - (enemy2Z / 2)), new Vector3(enemyBoxPos4.X + (enemy2X / 2), enemyBoxPos4.Y + (enemy2Y / 2), enemyBoxPos4.Z + (enemy2Z / 2)));
                        BoundingBox bb19 = new BoundingBox(new Vector3(enemyBoxPos5.X - (enemy2X / 2), enemyBoxPos5.Y - (enemy2Y / 2), enemyBoxPos5.Z - (enemy2Z / 2)), new Vector3(enemyBoxPos5.X + (enemy2X / 2), enemyBoxPos5.Y + (enemy2Y / 2), enemyBoxPos5.Z + (enemy2Z / 2)));

                        if (CheckCollisionBoxes(bb1, bb2) || CheckCollisionBoxes(bb1, bb3) || CheckCollisionBoxes(bb1, bb4) || CheckCollisionBoxes(bb1, bb18) || CheckCollisionBoxes(bb1, bb19))
                        {
                            collision = true;
                        }
                        if (CheckCollisionBoxes(bb1, bb17))
                        {
                            wincollision = true;
                        }
                        if (CheckCollisionBoxes(bb1, bb5))
                        {
                            scoreCollision1 = true;
                        }
                        if (CheckCollisionBoxes(bb1, bb6))
                        {
                            scoreCollision2 = true;
                        }
                        if (CheckCollisionBoxes(bb1, bb7))
                        {
                            scoreCollision3 = true;
                        }
                        if (CheckCollisionBoxes(bb1, bb8))
                        {
                            scoreCollision4 = true;
                        }
                        if (CheckCollisionBoxes(bb1, bb9))
                        {
                            scoreCollision5 = true;
                        }
                        if (CheckCollisionBoxes(bb1, bb10))
                        {
                            scoreCollision6 = true;
                        }
                        if (CheckCollisionBoxes(bb1, bb11))
                        {
                            scoreCollision7 = true;
                        }
                        if (CheckCollisionBoxes(bb1, bb12))
                        {
                            scoreCollision8 = true;
                        }
                        if (CheckCollisionBoxes(bb1, bb13))
                        {
                            scoreCollision9 = true;
                        }
                        if (CheckCollisionBoxes(bb1, bb14))
                        {
                            scoreCollision10 = true;
                        }
                        if (CheckCollisionBoxes(bb1, bb15))
                        {
                            scoreCollision11 = true;
                        }
                        if (CheckCollisionBoxes(bb1, bb16))
                        {
                            scoreCollision12 = true;
                        }

                        DrawCube(new Vector3(0.0f, 0.0f, 0.0f), 150.0f, 0.2f, 2.0f, WHITE);
                        DrawCube(new Vector3(cubePosition.X - 2.5f, 0.111f, 0.0f), 5f, 0.0f, cubez, new Color(230, 41, 55, 75));
                        DrawCube(winbox, winx, winy, winz, BLACK);
                        DrawCube(cubePosition, cubex, cubey, cubez, playerColor);
                        DrawCube(enemyBoxPos, enemyX, enemyY, enemyZ, BLACK);
                        DrawCube(enemyBoxPos1, enemyX, enemyY, enemyZ, BLACK);
                        DrawCube(enemyBoxPos2, enemy1X, enemy1Y, enemy1Z, BLACK);
                        DrawCube(enemyBoxPos3, enemy1X, enemy1Y, enemy1Z, BLACK);
                        DrawCube(enemyBoxPos4, enemy2X, enemy2Y, enemy2Z, BLACK);
                        DrawCube(enemyBoxPos5, enemy2X, enemy2Y, enemy2Z, BLACK);
                        DrawCube(enemyBoxPosUp1, enemyUp1X, enemyUp1Y, enemyUp1Z, BLACK);
                        DrawCube(enemyBoxPosUp2, enemyUp2X, enemyUp2Y, enemyUp2Z, BLACK);
                        DrawCube(enemyBoxPosUp3, enemyUp3X, enemyUp3Y, enemyUp3Z, BLACK);

                        DrawSphere(SpherePos1, SphereSize1, GOLD);
                        DrawSphere(SpherePos2, SphereSize2, GOLD);
                        DrawSphere(SpherePos3, SphereSize3, GOLD);
                        DrawSphere(SpherePos4, SphereSize4, GOLD);
                        DrawSphere(SpherePos5, SphereSize5, GOLD);
                        DrawSphere(SpherePos6, SphereSize6, GOLD);
                        DrawSphere(SpherePos7, SphereSize7, GOLD);
                        DrawSphere(SpherePos8, SphereSize8, GOLD);
                        DrawSphere(SpherePos9, SphereSize9, GOLD);
                        DrawSphere(SpherePos10, SphereSize10, GOLD);
                        DrawSphere(SpherePos11, SphereSize11, GOLD);
                        DrawSphere(SpherePos12, SphereSize12, GOLD);

                        for (int i = 0; i < 12; i++)
                        {
                            DrawCube(new Vector3(decorpos.X + i*5, decorpos.Y, decorpos.Z), decorx, decory, decorz, new Color(37, 150, 190, 200));
                            DrawSphere(new Vector3(decorSpherePos.X + i * 5, decorSpherePos.Y, decorSpherePos.Z), decorSphereSize, DARKPURPLE);
                        }

                        EndMode3D();

                        if (wincollision)
                        {
                            DrawText("YOU WIN!", 500, 60, 50, BLACK);
                        }
                        else if (collision)
                        {
                            playerColor = RED;
                            DrawText("YOU LOSE", 500, 60, 50, BLACK);
                            DrawText("PRESS R TO RETRY", 500, 120, 25, GRAY);
                        }
                        else
                        {
                            playerColor = BLUE;
                            cubePosition.X += 0.1f;
                            if (IsKeyDown(KeyboardKey.KEY_DOWN))
                            {
                                cubez += 0.04f;
                                cubey -= 0.05f;
                            }

                            if (IsKeyDown(KeyboardKey.KEY_UP))
                            {
                                cubez -= 0.04f;
                                cubey += 0.05f;
                            }

                            DrawText("LEVEL 1", 500, 60, 50, BLACK);
                            DrawText("Score:", 500, 100, 50, BLACK);
                            DrawText(score.ToString(), 700, 100, 50, BLACK);
                            DrawText("PRESS P TO PAUSE", 850, 560, 30, DARKGRAY);
                            DrawText("USE UP AND DOWN", 850, 610, 20, DARKGRAY);
                            DrawText("ARROW KEYS", 850, 640, 20, DARKGRAY);
                        }

                        if (scoreCollision1)
                        {
                            score += 10f;
                            scoreCollision1 = false;
                            SphereSize1 = 0;
                        }
                        if (scoreCollision2)
                        {
                            score += 10f;
                            scoreCollision2 = false;
                            SphereSize2 = 0;
                        }
                        if (scoreCollision3)
                        {
                            score += 5f;
                            scoreCollision3 = false;
                            SphereSize3 = 0;
                        }
                        if (scoreCollision4)
                        {
                            score += 5f;
                            scoreCollision4 = false;
                            SphereSize4 = 0;
                        }
                        if (scoreCollision5)
                        {
                            score += 5f;
                            scoreCollision5 = false;
                            SphereSize5 = 0;
                        }
                        if (scoreCollision6)
                        {
                            score += 5f;
                            scoreCollision6 = false;
                            SphereSize6 = 0;
                        }
                        if (scoreCollision7)
                        {
                            score += 5f;
                            scoreCollision7 = false;
                            SphereSize7 = 0;
                        }
                        if (scoreCollision8)
                        {
                            score += 5f;
                            scoreCollision8 = false;
                            SphereSize8 = 0;
                        }
                        if (scoreCollision9)
                        {
                            score += 5f;
                            scoreCollision9 = false;
                            SphereSize9 = 0;
                        }
                        if (scoreCollision10)
                        {
                            score += 10f;
                            scoreCollision10 = false;
                            SphereSize10 = 0;
                        }
                        if (scoreCollision11)
                        {
                            score += 10f;
                            scoreCollision11 = false;
                            SphereSize11 = 0;
                        }
                        if (scoreCollision12)
                        {
                            score += 10f;
                            scoreCollision12 = false;
                            SphereSize12 = 0;
                        }

                        cubey = Math.Min(Math.Max(cubey, 0.5f), 2.2f);
                        cubez = Math.Min(Math.Max(cubez, 0.2f), 1.25f);

                        break;
                    default: break;
                }
                EndDrawing();
            }

            CloseWindow();        

            return 0;
        }
    }
}