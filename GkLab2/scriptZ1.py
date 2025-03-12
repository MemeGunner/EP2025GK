import pygame

pygame.init()
win = pygame.display.set_mode((600, 600))
pygame.display.set_caption("Zadanie 1")

# deklarowanie kolorów
CZERWONY = (255, 0, 0)
ZOLTY = (255, 255, 0)
font = pygame.font.SysFont('comicsans', 30)

surf = pygame.Surface((65, 65), pygame.SRCALPHA)
surf46 = pygame.Surface((90, 90), pygame.SRCALPHA)
surf9 = pygame.Surface((90, 90), pygame.SRCALPHA)
jeden = pygame.draw.polygon(surf, ZOLTY,
                    [(58.9339, 50.0877),
                    (44.9974, 62.1638),
                    (26.7444, 64.7882),
                    (9.97019, 57.1276),
                    (0, 41.6143),
                    (0, 23.1737),
                    (9.97019, 7.66038),
                    (26.7444, 0),
                    (44.9974, 2.62423),
                    (58.9339, 14.7003),
                    (64.1293, 32.394),]
                    )
cztersze = pygame.draw.polygon(surf46, ZOLTY,
                    [(83.9778, 50.0877),
                    (76.0793, 62.1638),
                    (59.1385, 64.7882),
                    (38.534, 57.1276),
                    (20.8076, 41.6143),
                    (11.5872, 23.1737),
                    (13.8004, 7.66038),
                    (26.7443, -0.00015628),
                    (46.3095, 2.62423),
                    (66.2841, 14.7003),
                    (80.3263, 32.394),]
                    )
dziew = pygame.draw.polygon(surf9, ZOLTY,
                    [(58.9339, 79.5547),
                    (44.9974, 84.6625),
                    (26.7444, 78.1604),
                    (9.97019, 62.1127),
                    (0.000411773, 41.6145),
                    (0.000411773, 23.1739),
                    (9.97019, 12.6455),
                    (26.7444, 13.3721),
                    (44.9974, 25.1229),
                    (58.9339, 44.1673),
                    (64.1293, 64.4586),]
                    )
surf = pygame.transform.scale(surf, (300, 300))
surf46 = pygame.transform.scale(surf46, (300, 300))
surf9 = pygame.transform.scale(surf9, (300, 300))
label = font.render('0', 1, (255, 255, 255))
win.blit(label, (50, 550))
win.blit(surf, [150, 150])
#win.blit(surf46, [150, 150])
#win.blit(surf9, [150, 150])
pygame.display.update()
run = True
while run:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            run = False
        if event.type == pygame.KEYDOWN:
            if event.key == pygame.K_0:
                pygame.draw.rect(win, (0, 0, 0), (0, 0, 600, 600))
                label = font.render('0', 1, (255, 255, 255))
                win.blit(surf, [150, 150])
            elif event.key == pygame.K_1:
                pygame.draw.rect(win, (0, 0, 0), (0, 0, 600, 600))
                surf2 = pygame.transform.scale(surf, (150, 150))
                label = font.render('1', 1, (255, 255, 255))
                win.blit(surf2, [225, 225])
            elif event.key == pygame.K_2:
                pygame.draw.rect(win, (0, 0, 0), (0, 0, 600, 600))
                surf2 = pygame.transform.rotate(surf, 45)
                label = font.render('2', 1, (255, 255, 255))
                win.blit(surf2, [100, 100])
            elif event.key == pygame.K_3:
                pygame.draw.rect(win, (0, 0, 0), (0, 0, 600, 600))
                surf2 = pygame.transform.scale(surf, (150, 300))
                surf2 = pygame.transform.flip(surf2, False, True)
                label = font.render('3', 1, (255, 255, 255))
                win.blit(surf2, [225, 150])
            elif event.key == pygame.K_4: #!!!
                pygame.draw.rect(win, (0, 0, 0), (0, 0, 600, 600))
                label = font.render('4', 1, (255, 255, 255))
                win.blit(surf46, [150, 150])
            elif event.key == pygame.K_5:
                pygame.draw.rect(win, (0, 0, 0), (0, 0, 600, 600))
                surf2 = pygame.transform.scale(surf, (300, 150))
                label = font.render('5', 1, (255, 255, 255))
                win.blit(surf2, [150, 0])
            elif event.key == pygame.K_6: #!!!
                pygame.draw.rect(win, (0, 0, 0), (0, 0, 600, 600))
                label = font.render('6', 1, (255, 255, 255))
                surf2 = pygame.transform.rotate(surf46, 90)
                win.blit(surf2, [150, 150])
            elif event.key == pygame.K_7:
                pygame.draw.rect(win, (0, 0, 0), (0, 0, 600, 600))
                surf2 = pygame.transform.scale(surf, (150, 300))
                surf2 = pygame.transform.flip(surf2, True, True)
                label = font.render('7', 1, (255, 255, 255))
                win.blit(surf2, [225, 150])
            elif event.key == pygame.K_8:
                pygame.draw.rect(win, (0, 0, 0), (0, 0, 600, 600))
                surf2 = pygame.transform.scale(surf, (300, 150))
                surf2 = pygame.transform.rotate(surf2, -30)
                label = font.render('8', 1, (255, 255, 255))
                win.blit(surf2, [150, 300])
            elif event.key == pygame.K_9: #!!!
                pygame.draw.rect(win, (0, 0, 0), (0, 0, 600, 600))
                surf2 = pygame.transform.rotate(surf9, 180)
                win.blit(surf2, [150, 150])
                label = font.render('9', 1, (255, 255, 255))
            win.blit(label, (50, 550))
            pygame.display.update()
