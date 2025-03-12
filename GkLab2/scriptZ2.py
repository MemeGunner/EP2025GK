import pygame

pygame.init()
win = pygame.display.set_mode((600, 600))
pygame.display.set_caption("Zadanie 2")
# deklarowanie kolorów
NIEBIESKI = (0, 0, 255)

run = True
while run:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            run = False
    pygame.draw.rect(win, (255, 255, 255), (0, 0, 600, 600))
    pygame.draw.rect(win, NIEBIESKI, (250, 275, 100, 50))
    jeden = pygame.draw.polygon(win, NIEBIESKI, [(300, 275),(275, 225),(325, 225)])
    dwa = pygame.draw.polygon(win, NIEBIESKI, [(300, 325), (275, 375), (325, 375)])
    pygame.display.update()
